namespace Business_Logic.Models;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public IEnumerable<Project>? Projects { get; set; }
}
