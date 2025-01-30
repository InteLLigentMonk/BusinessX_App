using Microsoft.EntityFrameworkCore;

namespace BusinessX_Data.Entities;


[EntityTypeConfiguration(typeof(ProjectConfiguration))]
public class ProjectEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int StatusId { get; set; } // Forign key for StatusEntity
    public StatusEntity? Status { get; set; } // Navigation property
    public int CustomerId { get; set; } // Forign key for CustomerEntity
    public CustomerEntity? Customer { get; set; } // Navigation property
    public int ServiceId { get; set; } // Forign key for ServiceEntity
    public ServiceEntity? Service { get; set; } // Navigation property
    public int EmployeeId { get; set; } // Forign key for EmployeeEntity
    public EmployeeEntity? Employee { get; set; } // Navigation property

}
