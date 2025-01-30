namespace Business_Logic.Dtos;

public class EmployeeRegistrationForm
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public int RoleId { get; set; }
}
