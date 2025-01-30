using System.Linq.Expressions;
using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Interfaces
{
    public interface IServiceService : IBaseService<ServiceEntity, Service, ServiceRegistrationForm>
    {
        Task<Service> GetServiceWithProjectsAsync(Expression<Func<ServiceEntity, bool>> expression);
    }
}