﻿using BusinessLogic.Authorization;
using BusinessLogic.Models.Accounts;
using Cultura_New.Authorization;
using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Cultura_New.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        //helper methods
        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate(AuthenticateRequest model)
        {
            var response = await _accountService.Authenticate(model, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<ActionResult<AuthenticateResponse>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _accountService.RefreshToken(refreshToken, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }
        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken(RevokeTokenRequest model)
        {
            //accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });
            //users can revoke their own tokens and admins can revoke any tokens
            if (!employee.OwnsToken(token) && employee.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });


            await _accountService.RevokeToken(token, ipAddress());
            return Ok(new { message = "Token revoked" });

        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            await _accountService.Register(model, Request.Headers["origin"]);
            return Ok(new { message = "Registration succesful, please check your email for verification instructions" });

        }
        [AllowAnonymous]
        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail(VerifyEmailRequest model)
        {
            await _accountService.VerifyEmail(model.Token);
            return Ok(new { message = "Verification succesful, you can now login" });
        }
        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {
            await _accountService.ForgotPassword(model, Request.Headers["origin"]);
            return Ok(new { message = "Please check your email for password instructions" });
        }
        [AllowAnonymous]
        [HttpPost("validate-reset-token")]
        public async Task<IActionResult> ValidateResetToken(ValidateResetTokenRequest model)
        {
            await _accountService.ValidateResetToken(model);
            return Ok(new { message = "Token is valid" });
        }
        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {
            await _accountService.ResetPassword(model);
            return Ok(new { message = "Password reset succesful, you can now login" });
        }
        [Authorize(Role.Admin)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountResponse>>> GetAll()
        {
            var accounts = await _accountService.GetAll();
            return Ok(accounts);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AccountResponse>> GetById(int id)
        {
            //users can get their own account and admins can get any account
            if (id != employee.EmployeeId && employee.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });
            var account = await _accountService.GetById(id);
            return Ok(account);
        }
        [Authorize(Role.Admin)]
        [HttpPost]
        public async Task<ActionResult<AccountResponse>> Create(CreateRequest model)
        {
            var account = await _accountService.Create(model);
            return Ok(account);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<AccountResponse>> Update(int id, UpdateRequest model)
        {
            //users can update their own account and admins can update any account
            if (id != employee.EmployeeId && employee.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            //only admins can update role
            if (employee.Role != Role.Admin)
                model.Role = null;

            var account = await _accountService.Update(id, model);
            return Ok(account);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            //administrators can delete any account
            if (employee.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            await _accountService.Delete(id);
            return Ok(new { message = "Account deleted successfully" });

        }

    }
}
