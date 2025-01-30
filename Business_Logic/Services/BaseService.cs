using System.Linq.Expressions;
using Business_Logic.Interfaces;
using BusinessX_Data.Interfaces;

namespace Business_Logic.Services;

public abstract class BaseService<TEntity, TModel, TForm, TRepository> : IBaseService<TEntity, TModel, TForm>
    where TEntity : class
    where TModel : class
    where TForm : class
    where TRepository : IBaseRepository<TEntity>
{
    protected readonly TRepository _repository;

    protected BaseService(TRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TModel>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(CreateModel);
    }

    public async Task<TModel> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _repository.GetAsync(expression);
        return CreateModel(entity);
    }

    public async Task<TModel> AddAsync(TForm form)
    {
        var entity = CreateEntity(form);
        var result = await _repository.CreateAsync(entity);
        return CreateModel(result);
    }

    public async Task<TModel> UpdateAsync(Expression<Func<TEntity, bool>> expression, TModel model)
    {
        var entity = CreateEntity(model);
        var result = await _repository.UpdateAsync(expression, entity);
        return CreateModel(result);
    }

    public async Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _repository.DeleteAsync(expression);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _repository.ExistsAsync(expression);
    }

    protected abstract TModel CreateModel(TEntity entity);
    protected abstract TEntity CreateEntity(TForm form);
    protected abstract TEntity CreateEntity(TModel model);
}
