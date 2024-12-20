﻿using Domain.Interfaces;
using Domain.Models;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
namespace BusinessLogic.Services

{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;//доступ к репозиторию через интерфейс
        public UserService(IRepositoryWrapper repositoryWrapper)//Когда кто-то создает объект UserService, он должен передать в
        //этот параметр "управлялку" всеми репозиториями (например, UserRepository).
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<User>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }
        public async Task<User> GetById(int id)
        {
            var user = await _repositoryWrapper.User.FindByCondition(x => x.UserId == id);
            return user.First();
        }
        public async Task Create(User model)
        {
            try
            {
                await _repositoryWrapper.User.Create(model);
                await _repositoryWrapper.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                throw;  // Перебрасываем исключение дальше
            }
        }


        public async Task Update(User model)
        {
            await _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User.FindByCondition(x => x.UserId == id);
            _repositoryWrapper.User.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}
