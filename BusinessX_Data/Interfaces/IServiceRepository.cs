using System.Linq.Expressions;
using BusinessX_Data.Entities;

namespace BusinessX_Data.Interfaces;

public interface IServiceRepository : IBaseRepository<ServiceEntity>
{
    Task<ServiceEntity?> GetServiceWithProjectsAsync(Expression<Func<ServiceEntity, bool>> expression);
}