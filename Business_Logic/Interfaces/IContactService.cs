using System.Linq.Expressions;
using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Interfaces;

public interface IContactService : IBaseService<ContactEntity, Contact, ContactRegistrationForm>
{
    Task<Contact> GetContactWithCustomersAsync(Expression<Func<ContactEntity, bool>> expression);
}