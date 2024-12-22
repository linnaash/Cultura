using DataAccess.Models;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(Cultura_bdNewContext repositoryContext) : base(repositoryContext) // вызываем конструктор родительского класса
        {
        }
        public async Task<User> GetByIdWithToken(int userId) =>
            await DbContext.Set<User>().Include(x => x.RefreshTokens).AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
        public async Task<User> GetByEmailWithToken(string email) =>
            await DbContext.Set<User>().Include(x => x.RefreshTokens).AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

    }
}