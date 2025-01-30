namespace Business_Logic.Models;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public IEnumerable<Project>? Projects { get; set; }
}
