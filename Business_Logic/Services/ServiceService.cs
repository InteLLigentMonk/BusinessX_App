using Business_Logic.Dtos;
using Business_Logic.Factorys;
using Business_Logic.Models;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using Business_Logic.Interfaces;
using System.Linq.Expressions;


namespace Business_Logic.Services;

public class ServiceService(IServiceRepository repository) : BaseService<ServiceEntity, Service, ServiceRegistrationForm, IServiceRepository>(repository), IServiceService
{
    protected override Service CreateModel(ServiceEntity entity) => ServiceFactory.Create(entity);
    protected override ServiceEntity CreateEntity(ServiceRegistrationForm form) => ServiceFactory.Create(form);
    protected override ServiceEntity CreateEntity(Service model) => ServiceFactory.Create(model);


    public async Task<Service> GetServiceWithProjectsAsync(Expression<Func<ServiceEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        var entity = await _repository.GetServiceWithProjectsAsync(expression);
        if (entity == null)
            return null!;

        return ServiceFactory.Create(entity);
    }
}
