using System.ComponentModel.DataAnnotations;

namespace Business_Logic.Dtos;

public class CustomerRegistrationForm
{
    public string Name { get; set; } = null!;
    [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than zero.")]
    public int ContactId { get; set; }
}
