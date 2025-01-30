using System.ComponentModel.DataAnnotations;

namespace BusinessX_Data.Entities;

public class EmployeeEntity
{
    public int Id { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public int RoleId { get; set; } // Forign key for EmployeeRolesEntity
    public EmployeeRolesEntity? Role { get; set; } // Navigation property
    public ICollection<ProjectEntity>? Projects { get; set; } = []; // Navigation property
}
