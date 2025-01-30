using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Factorys;

public class CustomerFactory
{
    public static CustomerRegistrationForm Create() => new();

    public static CustomerEntity Create(CustomerRegistrationForm form) => new()
    {
        Name = form.Name,
        ContactId = form.ContactId,
    };

    public static Customer Create(CustomerEntity entity) => new()
    {
        Name = entity.Name,
        ContactId = entity.ContactId,
        Projects = entity.Projects?.Select(ProjectFactory.Create)
    };

    public static CustomerEntity Create(Customer model) => new()
    {
        Name = model.Name,
        ContactId = model.ContactId,
        Projects = model.Projects?.Select(ProjectFactory.Create).ToList()
    };
}
