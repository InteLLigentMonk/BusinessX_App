using BusinessX_Data.Dtos;
using BusinessX_Data.Entities;

namespace BusinessX_Data.Interfaces;

public interface IProjectRepository : IBaseRepository<ProjectEntity>
{
    Task<IEnumerable<RecentProjectsDto>> GetRecentAsync();
}
