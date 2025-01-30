namespace Business_Logic.Models;

public class Customer
{
    public string Name { get; set; } = null!;
    public int ContactId { get; set; }
    public IEnumerable<Project>? Projects { get; set; }
    public string Slug => Name.Replace(" ", string.Empty);


}
