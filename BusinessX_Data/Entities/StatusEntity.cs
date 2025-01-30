namespace BusinessX_Data.Entities;

public class StatusEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
     public ICollection<ProjectEntity>? Projects { get; set; } // Navigation property
}
