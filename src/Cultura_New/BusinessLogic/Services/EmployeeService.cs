using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace BusinessLogic.Services

{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;//доступ к репозиторию через интерфейс
        public EmployeeService(IRepositoryWrapper repositoryWrapper)//Когда кто-то создает объект UserService, он должен передать в
        //этот параметр "управлялку" всеми репозиториями (например, UserRepository).
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Employee>> GetAll()
        {
            return await _repositoryWrapper.Employee.FindAll();
        }
        public async Task<Employee> GetById(int id)
        {
            var employee = await _repositoryWrapper.Employee.FindByCondition(x => x.EmployeeId == id);
            return employee.First();
        }
        public async Task Create(Employee model)
        {
            await _repositoryWrapper.Employee.Create(model);
            await _repositoryWrapper.Save();
        }


        public async Task Update(Employee model)
        {
            await _repositoryWrapper.Employee.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var employee = await _repositoryWrapper.Employee.FindByCondition(x => x.EmployeeId == id);
            _repositoryWrapper.Employee.Delete(employee.First());
            _repositoryWrapper.Save();
        }
    }
}
