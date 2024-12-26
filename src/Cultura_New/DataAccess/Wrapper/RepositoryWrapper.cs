using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;
namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly Cultura_bdNewContext _bdContext;
        private IEmployeeRepository _employee;
        public IEmployeeRepository Employee //IUserRepository - тип возвращаемого значения, будет возвращать объект,который реализует
        //интерфейс IUserRepository
        {
            get
            {
                if (_employee == null)//проверка, был ли уже создан экземпляр репозитория пользователей
                {
                    _employee = new EmployeeRepository(_bdContext);
                }
                return _employee;
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
