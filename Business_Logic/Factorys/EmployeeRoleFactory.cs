using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Factorys;

public class EmployeeRoleFactory
{
    public static EmployeeRoleRegistrationForm Create() => new();

    public static EmployeeRolesEntity Create(EmployeeRoleRegistrationForm form) => new()
    {
        Role = form.Role
    };

    public static EmployeeRole Create(EmployeeRolesEntity entity) => new()
    {
        Id = entity.Id,
        Role = entity.Role,
        Employees = entity.Employees?.Select(EmployeeFactory.Create)
    };

    public static EmployeeRolesEntity Create(EmployeeRole model) => new()
    {
        Id = model.Id,
        Role = model.Role,
        Employees = model.Employees?.Select(EmployeeFactory.Create).ToList()
    };
};
