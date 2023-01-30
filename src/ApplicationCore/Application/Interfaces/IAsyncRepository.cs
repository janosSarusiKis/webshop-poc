using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetAllByExpressionAsync(Expression<Func<T, bool>> filterQuery);
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<IList<T>> AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> CheckIfExistsByIdAsync(Guid id);
    }
}
