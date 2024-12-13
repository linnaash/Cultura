using Domain.Interfaces;
using Domain.Models;
using DataAccess.Repositories;
using DataAccess.Models;
namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Cultura_bdNewContext _bdContext;
        private IUserRepository _user;
        public IUserRepository User //IUserRepository - тип возвращаемого значения, будет возвращать объект,который реализует
        //интерфейс IUserRepository
        {
            get
            {
                if (_user == null)//проверка, был ли уже создан экземпляр репозитория пользователей
                {
                    _user = new UserRepository(_bdContext);
                }
                return _user;
            }
        }
        public RepositoryWrapper(Cultura_bdNewContext bdContext)
        {
            _bdContext = bdContext;
        }
        public async Task Save()
        {
            if (_bdContext.ChangeTracker.HasChanges())
            {
                await _bdContext.SaveChangesAsync();
            }
        }

    }
}
