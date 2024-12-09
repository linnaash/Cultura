using Domain.Models;

namespace Domain.Interfaces

{
    public interface IUserRepository:IRepositoryBase<User>//юзер интерфейс наследует интерфейса базы(доступ к данным и методы)
    {
        Task<User> GetByIdWithToken(int userId);
        Task<User> GetByEmailWithToken(string email);
    }
}
