namespace Business_Logic.Models;

public class EmployeeRole
{
    public int Id { get; set; }
    public string Role { get; set; } = null!;
    public IEnumerable<Employee>? Employees { get; set; } 
}
