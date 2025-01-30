
using System.ComponentModel.DataAnnotations;

namespace BusinessX_Data.Entities;

public class ContactEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string Email { get; set; } = null!;
    public ICollection<CustomerEntity>? Customers { get; set; } // Navigation property

}