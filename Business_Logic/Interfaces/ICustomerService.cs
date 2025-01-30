using System.Linq.Expressions;
using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Interfaces
{
    public interface ICustomerService : IBaseService<CustomerEntity, Customer, CustomerRegistrationForm>
    {
        Task<Customer> GetCustomerWithProjectsAsync(Expression<Func<CustomerEntity, bool>> expression);
 }
}