using System.Linq.Expressions;
using BusinessX_Data.Dtos;
using BusinessX_Data.Entities;

namespace BusinessX_Data.Interfaces;

public interface IProjectRepository : IBaseRepository<ProjectEntity>
{
    Task<ProjectDetailsDto> GetProjectWithDetailsAsync(Expression<Func<ProjectEntity, bool>> expression);
    Task<IEnumerable<RecentProjectsDto>> GetRecentAsync();
}
