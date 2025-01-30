using System.Linq.Expressions;
using BusinessX_Data.Entities;

namespace BusinessX_Data.Interfaces;

public interface IEmployeeRolesRepository : IBaseRepository<EmployeeRolesEntity>
{
    Task<EmployeeRolesEntity?> GetEmployeeRoleWithEmployeesAsync(Expression<Func<EmployeeRolesEntity, bool>> expression);
}