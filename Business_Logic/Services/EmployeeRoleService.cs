using Business_Logic.Dtos;
using Business_Logic.Factorys;
using Business_Logic.Interfaces;
using Business_Logic.Models;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using System.Linq.Expressions;


namespace Business_Logic.Services;

public class EmployeeRoleService(IEmployeeRolesRepository repository) : BaseService<EmployeeRolesEntity, EmployeeRole, EmployeeRoleRegistrationForm, IEmployeeRolesRepository>(repository), IEmployeeRoleService
{
    protected override EmployeeRole CreateModel(EmployeeRolesEntity entity) => EmployeeRoleFactory.Create(entity);
    protected override EmployeeRolesEntity CreateEntity(EmployeeRoleRegistrationForm form) => EmployeeRoleFactory.Create(form);
    protected override EmployeeRolesEntity CreateEntity(EmployeeRole model) => EmployeeRoleFactory.Create(model);


    public async Task<EmployeeRole> GetEmployeeRoleWithEmployeesAsync(Expression<Func<EmployeeRolesEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        var entity = await _repository.GetEmployeeRoleWithEmployeesAsync(expression);
        if (entity == null)
            return null!;

        return EmployeeRoleFactory.Create(entity);
    }
}
