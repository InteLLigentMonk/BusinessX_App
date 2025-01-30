using System.Linq.Expressions;
using BusinessX_Data.Entities;

namespace BusinessX_Data.Interfaces;

public interface ICustomerRepository : IBaseRepository<CustomerEntity>
{
    Task<CustomerEntity?> GetCustomerWithProjectsAsync(Expression<Func<CustomerEntity, bool>> expression);
}