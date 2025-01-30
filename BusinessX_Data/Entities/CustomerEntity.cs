using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BusinessX_Data.Entities;

[PrimaryKey(nameof(Name), nameof(ContactId))]
public class CustomerEntity
{
    private string _name = null!;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            Slug = value.Replace(" ", string.Empty);
        }
    }
    public int ContactId { get; set; } // Forign key for ContactEntity
    public ContactEntity? Contact { get; set; } // Navigation property
    public ICollection<ProjectEntity>? Projects { get; set; } // Navigation property
    [Required]
    public string Slug { get; private set; } = null!;
}
