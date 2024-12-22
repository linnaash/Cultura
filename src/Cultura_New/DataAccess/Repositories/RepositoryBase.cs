using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected Cultura_bdNewContext DbContext { get; set; } //DbContext — это объект, который управляет подключением
                                                               //и доступом к базе данных.
        public RepositoryBase(Cultura_bdNewContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<List<T>> FindAll() => await DbContext.Set<T>().AsNoTracking().ToListAsync();
        //Set<T>() — это метод, который позволяет получить
        //доступ к таблице для работы с данными для типа T. То есть, Set<T> возвращает набор данных (набор сущностей), соответствующий
        //типу T из базы данных.
        //AsNoTracking - не отслеживает изменения, то если на api удалить данные, то в базе останутся
        public async Task<List<T>> FindByCondition(Expression<Func<T, bool>> condition) => await DbContext.Set<T>().Where(condition).AsNoTracking().ToListAsync();
        public async Task Create(T entity) => await DbContext.Set<T>().AddAsync(entity);
        public async Task Update(T entity) => DbContext.Set<T>().Update(entity);
        public async Task Delete(T entity) => DbContext.Set<T>().Remove(entity);

    }
}