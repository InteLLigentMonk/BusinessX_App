using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Factorys;

public class EmployeeFactory
{
    public static EmployeeRegistrationForm Create() => new();
    public static EmployeeEntity Create(EmployeeRegistrationForm form) => new()
    {
        Firstname = form.Firstname,
        Lastname = form.Lastname,
        RoleId = form.RoleId
    };

    public static Employee Create(EmployeeEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.Firstname,
        LastName = entity.Lastname,
        RoleId = entity.RoleId,
        Projects = entity.Projects?.Select(ProjectFactory.Create)
    };

    public static EmployeeEntity Create(Employee model) => new()
    {
        Id = model.Id,
        Firstname = model.FirstName,
        Lastname = model.LastName,
        RoleId = model.RoleId,
        Projects = model.Projects?.Select(ProjectFactory.Create).ToList()
    };
}
