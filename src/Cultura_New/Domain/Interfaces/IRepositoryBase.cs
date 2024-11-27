using System.Linq.Expressions;
using Domain.Models;

namespace Domain.Interfaces
{

    public interface IRepositoryBase<T>
    {
        Task<List<T>> FindAll();
        Task<List<T>> FindByCondition(Expression<Func<T, bool>> condition);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        
    }

}
