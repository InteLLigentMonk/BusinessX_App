namespace Business_Logic.Models;

public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string Email { get; set; } = null!;
    public IEnumerable<Customer>? Customers { get; set; }


}
