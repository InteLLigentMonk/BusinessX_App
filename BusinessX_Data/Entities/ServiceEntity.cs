using Microsoft.EntityFrameworkCore;

namespace BusinessX_Data.Entities;

[EntityTypeConfiguration(typeof(ServiceConfiguration))]
public class ServiceEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public ICollection<ProjectEntity>? Projects { get; set; } // Navigation property
}
