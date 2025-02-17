
using System.Linq.Expressions;

namespace BusinessX_Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
        Task<int> SaveAsync();
    }
}