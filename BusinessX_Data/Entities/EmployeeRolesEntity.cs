namespace BusinessX_Data.Entities;

public class EmployeeRolesEntity
{
    public int Id { get; set; }
    public string Role { get; set; } = null!;
    public ICollection<EmployeeEntity>? Employees { get; set; } // Navigation property
}
