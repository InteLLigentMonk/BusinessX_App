using BusinessX_Data.Contexts;
using BusinessX_Data.Dtos;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessX_Data.Repositorys;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    private readonly DataContext _context = context;

    public async Task<IEnumerable<RecentProjectsDto>> GetRecentAsync()
    {
        //Return 5 most recent projects and include ony Name from status table
        return await _context.Projects
            .Include(p => p.Status)
            .OrderByDescending(p => p.StartDate)
            .Take(5)
            .Select(p => new RecentProjectsDto
            {
                Id = p.Id,
                Name = p.Name,
                EndDate = p.EndDate,
                StatusId = p.StatusId,
                StatusName = p.Status!.Name
            })
               .ToListAsync();


    }
}
