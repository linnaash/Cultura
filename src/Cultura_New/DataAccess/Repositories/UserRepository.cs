using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class UserRepository: RepositoryBase<User>,IUserRepository
    {
        public UserRepository(Cultura_bdContext context) : base(context) // вызываем конструктор родительского класса
        {
        }

    }
}
