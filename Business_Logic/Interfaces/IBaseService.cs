using System.Linq.Expressions;

namespace Business_Logic.Interfaces;

public interface IBaseService<TEntity, TModel, TForm>
{
    Task<IEnumerable<TModel>> GetAllAsync();
    Task<TModel> GetAsync(Expression<Func<TEntity, bool>> expression);
    Task<TModel> AddAsync(TForm form);
    Task<TModel> UpdateAsync(Expression<Func<TEntity, bool>> expression, TModel model);
    Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
}
