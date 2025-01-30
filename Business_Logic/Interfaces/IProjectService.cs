using Business_Logic.Dtos;
using Business_Logic.Models;
using BusinessX_Data.Dtos;
using BusinessX_Data.Entities;

namespace Business_Logic.Interfaces
{
    public interface IProjectService : IBaseService<ProjectEntity, Project, ProjectRegistrationForm>
    {
        Task<IEnumerable<RecentProjectsDto>> GetRecentAsync();
    }
}