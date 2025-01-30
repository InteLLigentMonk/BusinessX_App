using Business_Logic.Dtos;
using Business_Logic.Factorys;
using Business_Logic.Models;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using Business_Logic.Interfaces;
using System.Linq.Expressions;


namespace Business_Logic.Services;

public class EmployeeService(IEmployeeRepository repository) : BaseService<EmployeeEntity, Employee, EmployeeRegistrationForm, IEmployeeRepository>(repository), IEmployeeService
{
    protected override Employee CreateModel(EmployeeEntity entity) => EmployeeFactory.Create(entity);
    protected override EmployeeEntity CreateEntity(EmployeeRegistrationForm form) => EmployeeFactory.Create(form);
    protected override EmployeeEntity CreateEntity(Employee model) => EmployeeFactory.Create(model);


    public async Task<Employee> GetEmployeeWithProjectsAsync(Expression<Func<EmployeeEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        var entity = await _repository.GetEmployeeWithProjectsAsync(expression);
        if (entity == null)
            return null!;

        return EmployeeFactory.Create(entity);
    }
}

