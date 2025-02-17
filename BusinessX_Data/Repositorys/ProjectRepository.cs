using System.Linq.Expressions;
using BusinessX_Data.Contexts;
using BusinessX_Data.Dtos;
using BusinessX_Data.Entities;
using BusinessX_Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessX_Data.Repositorys;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    private readonly DataContext _context = context;

    public async Task<ProjectDetailsDto> GetProjectWithDetailsAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        // Return project, include status.name, customer.name, service.name, and employee.firstName and lastName
        var project = await _context.Projects
            .Include(p => p.Status)
            .Include(p => p.Customer)
            .ThenInclude(c => c!.Contact)
            .Include(p => p.Service)
            .Include(p => p.Employee)
            .FirstOrDefaultAsync(expression);

        if (project == null)
        {
            return null!;
        }

        var contact = project.Customer?.Contact;
        var contactDto = contact == null ? null : new ContactDto
        {
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            PhoneNumber = contact.PhoneNumber!,
            Email = contact.Email,
        };

        return new ProjectDetailsDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            StatusId = project.StatusId,
            StatusName = project.Status?.Name ?? string.Empty,
            CustomerName = project.Customer?.Name ?? string.Empty,
            CustomerContact = contactDto!,
            ServiceId = project.ServiceId,
            ServiceName = project.Service?.Name ?? string.Empty,
            EmployeeId = project.EmployeeId,
            EmployeeFirstName = project.Employee?.Firstname ?? string.Empty,
            EmployeeLastName = project.Employee?.Lastname ?? string.Empty
        };
    }

    public async Task<IEnumerable<RecentProjectsDto>> GetRecentAsync()
    {
        //Return 5 most recent projects and include only Name from status table
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
