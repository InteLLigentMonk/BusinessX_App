using System.Linq.Expressions;
using BusinessX_Data.Entities;

namespace BusinessX_Data.Interfaces;

public interface IEmployeeRepository : IBaseRepository<EmployeeEntity>
{
    Task<EmployeeEntity?> GetEmployeeWithProjectsAsync(Expression<Func<EmployeeEntity, bool>> expression);
}