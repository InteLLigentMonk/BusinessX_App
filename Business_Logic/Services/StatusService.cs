using Business_Logic.Dtos;
using Business_Logic.Factorys;
using Business_Logic.Interfaces;
using Business_Logic.Models;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;


namespace Business_Logic.Services;

public class StatusService(IStatusRepository repository) : BaseService<StatusEntity, Status, StatusRegistrationForm, IStatusRepository>(repository), IStatusService
{
    protected override Status CreateModel(StatusEntity entity) => StatusFactory.Create(entity);
    protected override StatusEntity CreateEntity(StatusRegistrationForm form) => StatusFactory.Create(form);
    protected override StatusEntity CreateEntity(Status model) => StatusFactory.Create(model);

}
