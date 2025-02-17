using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Factorys;

public class ProjectFactory
{
    public static ProjectRegistrationForm Create() => new();
    public static ProjectEntity Create(ProjectRegistrationForm form) => new()
    {
        Name = form.Name,
        Description = form.Description,
        StartDate = form.StartDate?.ToUniversalTime(),
        EndDate = form.EndDate.ToUniversalTime(),
        StatusId = form.StatusId,
        CustomerId = form.CustomerId,
        ContactId = form.ContactId,
        ServiceId = form.ServiceId,
        EmployeeId = form.EmployeeId
    };
   
    public static Project Create(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        StartDate = entity.StartDate?.ToUniversalTime(),
        EndDate = entity.EndDate.ToUniversalTime(),
        StatusId = entity.StatusId,
        CustomerId = entity.CustomerId,
        ContactId = entity.ContactId,
        ServiceId = entity.ServiceId,
        EmployeeId = entity.EmployeeId
    };

    public static ProjectEntity Create(Project model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        StartDate = model.StartDate?.ToUniversalTime(),
        EndDate = model.EndDate.ToUniversalTime(),
        StatusId = model.StatusId,
        CustomerId = model.CustomerId,
        ContactId = model.ContactId,
        ServiceId = model.ServiceId,
        EmployeeId = model.EmployeeId
    };
}
