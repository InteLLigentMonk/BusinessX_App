using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Factorys;

public class ServiceFactory
{
    public static ServiceRegistrationForm Create() => new();

    public static ServiceEntity Create(ServiceRegistrationForm form) => new()
    {
        Name = form.Name,
        Price = form.Price
    };

    public static Service Create(ServiceEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Price = entity.Price,
        Projects = entity.Projects?.Select(ProjectFactory.Create)
    };

    public static ServiceEntity Create(Service model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Price = model.Price,
        Projects = model.Projects?.Select(ProjectFactory.Create).ToList()
    };
};
