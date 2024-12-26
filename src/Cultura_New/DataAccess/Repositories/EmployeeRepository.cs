using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Cultura_bdNewContext dbContext) : base(dbContext) // вызываем конструктор родительского класса
        {
        }
        public async Task<Employee> GetByIdWithToken(int employeeId) =>
            await DbContext.Set<Employee>().Include(x => x.RefreshTokens).AsNoTracking().FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
        //public async Task<Employee> GetByEmailWithToken(string email) =>
        //    await DbContext.Set<Employee>().Include(x => x.RefreshTokens).AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        public async Task<Employee> GetByEmailWithToken(string email)
        {
            return await DbContext.Set<Employee>()
                .Include(x => x.RefreshTokens)  // Убедитесь, что здесь не используется столбец, которого нет
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);
        }

    }
}
