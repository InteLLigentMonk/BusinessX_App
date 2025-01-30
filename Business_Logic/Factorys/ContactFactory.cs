using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Factorys;

public class ContactFactory
{
    public static ContactRegistrationForm Create() => new();

    public static ContactEntity Create(ContactRegistrationForm form) => new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        PhoneNumber = form.PhoneNumber,
        Email = form.Email
    };

    public static Contact Create(ContactEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        PhoneNumber = entity.PhoneNumber,
        Email = entity.Email,
        Customers = entity.Customers?.Select(CustomerFactory.Create)
    };

    public static ContactEntity Create(Contact model) => new()
    {
        Id = model.Id,
        FirstName = model.FirstName,
        LastName = model.LastName,
        PhoneNumber = model.PhoneNumber,
        Email = model.Email,
        Customers = model.Customers?.Select(CustomerFactory.Create).ToList()
    };
};