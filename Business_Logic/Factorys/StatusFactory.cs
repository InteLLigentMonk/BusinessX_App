using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Factorys;

public class StatusFactory
{
    public static StatusRegistrationForm Create() => new();

    public static StatusEntity Create(StatusRegistrationForm form) => new()
    {
        Name = form.Name
    };

    public static Status Create(StatusEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Projects = entity.Projects?.Select(ProjectFactory.Create)
    };

    public static StatusEntity Create(Status model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Projects = model.Projects?.Select(ProjectFactory.Create).ToList()
    };
};
