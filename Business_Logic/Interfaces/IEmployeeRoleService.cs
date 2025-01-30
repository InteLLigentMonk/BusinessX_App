using System.Linq.Expressions;
using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Interfaces;

public interface IEmployeeRoleService : IBaseService<EmployeeRolesEntity, EmployeeRole, EmployeeRoleRegistrationForm>
{
    Task<EmployeeRole> GetEmployeeRoleWithEmployeesAsync(Expression<Func<EmployeeRolesEntity, bool>> expression);
}