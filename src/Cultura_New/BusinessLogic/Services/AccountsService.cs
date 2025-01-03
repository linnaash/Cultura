﻿using BusinessLogic.Authorization;
using BusinessLogic.Helpers;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using Domain.Interfaces;
using MapsterMapper;
using Domain.Models;
using Domain.Entities;
using BusinessLogic.Models.Accounts;



namespace BusinessLogic.Services
{
    public class AccountsService : IAccountService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public AccountsService(
            IRepositoryWrapper repositoryWrapper,
            IJwtUtils jwtUtils,
            IMapper mapper,
            AppSettings appSettings,
            IEmailService emailService)
        {
            _repositoryWrapper = repositoryWrapper;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _appSettings = appSettings;
            _emailService = emailService;
        }
        private void removeOldRefreshTokens(Employee account)
        {
            account.RefreshTokens.RemoveAll(x =>
            x.IsActive &&
            x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var account = await _repositoryWrapper.Employee.GetByEmailWithToken(model.Email);

            //validate
            if (account == null || !account.IsVerified || !BCrypt.Net.BCrypt.Verify(model.Password, account.Password))//PasswordHash
                throw new AppException("EmailGetByEmailWithToken or password is incorrect");

            //authentication successful so generate jwt and refresh tokens
            var jwtToken = _jwtUtils.GenerateJwtToken(account);
            var refreshToken = await _jwtUtils.GenerateResreshToken(ipAddress);
            account.RefreshTokens.Add(refreshToken);

            //remove old refresh tokens from account
            removeOldRefreshTokens(account);

            //save changes to db
            await _repositoryWrapper.Employee.Update(account);
            await _repositoryWrapper.Save();

            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = refreshToken.Token;
            return response;

        }

        public async Task<AccountResponse> Create(CreateRequest model)
        {
            //validate
            if ((await _repositoryWrapper.Employee.FindByCondition(x => x.Email == model.Email)).Count > 0)
                throw new AppException($"Email '{model.Email}' is already registered");

            //map model to new account object
            var account = _mapper.Map<Employee>(model);
            account.Created = DateTime.UtcNow;
            account.Verified = DateTime.UtcNow;
            //hash password
            account.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            //save account

            await _repositoryWrapper.Employee.Update(account);
            await _repositoryWrapper.Save();

            return _mapper.Map<AccountResponse>(account);
        }
        private async Task<Employee> getAccount(int id)
        {
            var account = (await _repositoryWrapper.Employee.FindByCondition(x => x.EmployeeId == id)).FirstOrDefault();
            if (account == null) throw new KeyNotFoundException("Account not found");
            return account;
        }
        public async Task<AccountResponse> Update(int id, UpdateRequest model)
        {
            var account = await getAccount(id);

            //validate
            if (account.Email != model.Email && (await _repositoryWrapper.Employee.FindByCondition(x => x.Email == model.Email)).Count > 0)
                throw new AppException($"Email ' {model.Email}' is already registered");
            //Hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            }
            //copy model to account and save
            _mapper.Map(model, account);
            account.Updated = DateTime.UtcNow;
            await _repositoryWrapper.Employee.Update(account);
            await _repositoryWrapper.Save();

            return _mapper.Map<AccountResponse>(account);
        }

        public async Task Delete(int id)
        {
            var account = await getAccount(id);
            await _repositoryWrapper.Employee.Delete(account);
            await _repositoryWrapper.Save();
        }
        public async Task<IEnumerable<AccountResponse>> GetAll()
        {
            var accounts = await _repositoryWrapper.Employee.FindAll();
            return _mapper.Map<IList<AccountResponse>>(accounts);
        }

        public async Task<AccountResponse> GetById(int id)
        {
            var account = await getAccount(id);
            return _mapper.Map<AccountResponse>(account);
        }

        private async Task<string> generateResetToken()
        {
            //token is a cryptographically strong random sequence of values
            var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

            //ensure token is unique by checking agains db
            var tokenIsUnique = (await _repositoryWrapper.Employee.FindByCondition(x => x.ResetToken == token)).Count == 0;
            if (!tokenIsUnique)
                return await generateResetToken();

            return token;
        }
        public async Task ForgotPassword(ForgotPasswordRequest model, string origin)
        {
            var account = (await _repositoryWrapper.Employee.FindByCondition(x => x.Email == model.Email)).FirstOrDefault();

            //always return ok response to prevent email enumeration
            if (account == null) return;

            //create reset token that expires after 1 day
            account.ResetToken = await generateResetToken();
            account.ResetTokenExpires = DateTime.UtcNow.AddDays(1);

            await _repositoryWrapper.Employee.Update(account);
            await _repositoryWrapper.Save();
        }
        private async Task<Employee> getAccountByRefreshToken(string token)
        {
            var account = (await _repositoryWrapper.Employee.FindByCondition(u => u.RefreshTokens.Any(t => t.Token == token))).SingleOrDefault();
            if (account == null) throw new AppException("Invalid token");
            return account;
            
        }
        private async Task<RefreshToken> rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            var newRefreshToken = await _jwtUtils.GenerateResreshToken(ipAddress);
            revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return refreshToken;

        }
        private void revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }
        private void revokeDescendantRefreshTokens(RefreshToken refreshToken, Employee account, string ipAddress, string reason)
        {
            //recursively traverse the refresh token chain and ensure all descendants are revoked
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                var childToken = account.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken.IsActive)
                    revokeRefreshToken(childToken, ipAddress, reason);
                else
                    revokeDescendantRefreshTokens(childToken, account, ipAddress, reason);
            }
        }

        public async Task<AuthenticateResponse> RefreshToken(string token, string ipAddress)
        {
            var account = await getAccountByRefreshToken(token);
            var refreshToken = account.RefreshTokens.Single(x => x.Token == token);

            if (refreshToken.IsRevoked)
            {
                //revoke all descendant tokens in case this token has been compromised
                revokeDescendantRefreshTokens(refreshToken, account, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
                await _repositoryWrapper.Employee.Update(account);
                await _repositoryWrapper.Save();
            }
            if (!refreshToken.IsActive)
            {
                throw new AppException("Invalid token");
            }
            //replace old refresh token with a new one (rotate token)
            var newRefreshToken = await rotateRefreshToken(refreshToken, ipAddress);
            account.RefreshTokens.Add(newRefreshToken);

            //remove old refresh tokens from account
            removeOldRefreshTokens(account);

            //save changes to db
            await _repositoryWrapper.Employee.Update(account);
            await _repositoryWrapper.Save();

            //generate new jwt
            var jwtToken = _jwtUtils.GenerateJwtToken(account);

            //return data in authenticate response object
            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = newRefreshToken.Token;
            return response;

        }
        private async Task<string> generateVerificationToken()
        {
            //token is a cryptographically strong random sequence of values
            var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

            //ensure token is unique by checking agains db
            var tokenIsUnique = (await _repositoryWrapper.Employee.FindByCondition(x => x.VerificationToken == token)).Count == 0;
            if (!tokenIsUnique)
                return await generateVerificationToken();

            return token;
        }
        public async Task Register(RegisterRequest model, string origin)
        {
            //validate
            if ((await _repositoryWrapper.Employee.FindByCondition(x => x.Email == model.Email)).Count > 0)
            {
                return;
            }

            //map model to new account object
            var account = _mapper.Map<Employee>(model);

            //first registered account is in admin
            var isFirstAccount = (await _repositoryWrapper.Employee.FindAll()).Count == 0;
            account.Role = isFirstAccount ? Role.Admin : Role.User;
            //account.Role = Role.User;
            account.Created = DateTime.UtcNow;
            account.Verified = DateTime.UtcNow;
            account.VerificationToken = await generateVerificationToken();

            //hash password
            account.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            //save account
            await _repositoryWrapper.Employee.Create(account);
            await _repositoryWrapper.Save();

        }
        private async Task<Employee> getAccountByResetToken(string token)
        {
            var account = (await _repositoryWrapper.Employee.FindByCondition(x =>
            x.ResetToken == token && x.ResetTokenExpires > DateTime.UtcNow)).SingleOrDefault();
            if (account == null) throw new AppException("Invalid token");
            return account;
        }

        public async Task ResetPassword(ResetPasswordRequest model)
        {
            var account = await getAccountByResetToken(model.Token);

            //update password and remove reset token
            account.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            account.PasswordReset = DateTime.UtcNow;
            account.ResetToken = null;
            account.ResetTokenExpires = null;

            await _repositoryWrapper.Employee.Update(account);
            await _repositoryWrapper.Save();
        }

        public async Task RevokeToken(string token, string ipAddress)
        {
            var account = await getAccountByRefreshToken(token);
            var refreshToken = account.RefreshTokens.Single(x => x.Token == token)
;
            if (!refreshToken.IsActive)
                throw new AppException("Invalid token");

            //revoke token and save
            revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
            await _repositoryWrapper.Employee.Update(account);
            await _repositoryWrapper.Save();
        }



        public async Task ValidateResetToken(ValidateResetTokenRequest model)
        {
            await getAccountByResetToken(model.Token);
        }

        public async Task VerifyEmail(string token)
        {
            var account = (await _repositoryWrapper.Employee.FindByCondition(x => x.VerificationToken == token)).FirstOrDefault();

            if (account == null)
                throw new AppException("Verification failed");

            account.Verified = DateTime.UtcNow;
            account.VerificationToken = null;

            await _repositoryWrapper.Employee.Update(account);
            await _repositoryWrapper.Save();
        }
    }
}
