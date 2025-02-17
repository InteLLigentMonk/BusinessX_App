using Business_Logic.Dtos;
using Business_Logic.Factorys;
using Business_Logic.Models;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using Business_Logic.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace Business_Logic.Services;

public class CustomerService(ICustomerRepository repository) : BaseService<CustomerEntity, Customer, CustomerRegistrationForm, ICustomerRepository>(repository), ICustomerService
{
    protected override Customer CreateModel(CustomerEntity entity) => CustomerFactory.Create(entity);
    protected override CustomerEntity CreateEntity(CustomerRegistrationForm form) => CustomerFactory.Create(form);
    protected override CustomerEntity CreateEntity(Customer model) => CustomerFactory.Create(model);



    public async Task<Customer> GetCustomerWithProjectsAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        var entity = await _repository.GetCustomerWithProjectsAsync(expression);
        if (entity == null)
            return null!;

        return CustomerFactory.Create(entity);
    }
}
