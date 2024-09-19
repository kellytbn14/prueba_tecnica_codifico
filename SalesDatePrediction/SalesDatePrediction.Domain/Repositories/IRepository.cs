using SalesDatePrediction.Domain.Models;
using System.Linq.Expressions;

namespace SalesDatePrediction.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : ModelBase
    {
        Task AddVoidAsync(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    }
}
