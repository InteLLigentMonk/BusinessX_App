using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Entities;

namespace Business_Logic.Interfaces
{
    public interface IStatusService : IBaseService<StatusEntity, Status, StatusRegistrationForm>
    {
    }
}