using Domain.Models;

namespace Domain.Interfaces

{
    public interface IEmployeeRepository : IRepositoryBase<Employee>//юзер интерфейс наследует интерфейса базы(доступ к данным и методы)
    {
        Task<Employee> GetByIdWithToken(int employeeId);
        Task<Employee> GetByEmailWithToken(string email);
    }
}
