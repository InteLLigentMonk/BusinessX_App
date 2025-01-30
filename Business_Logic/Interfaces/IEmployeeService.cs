using System.Linq.Expressions;
using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Interfaces
{
    public interface IEmployeeService : IBaseService<EmployeeEntity, Employee, EmployeeRegistrationForm>
    {
        Task<Employee> GetEmployeeWithProjectsAsync(Expression<Func<EmployeeEntity, bool>> expression);
    }
}