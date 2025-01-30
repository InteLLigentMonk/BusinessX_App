namespace BusinessX_Data.Dtos
{
    public class RecentProjectsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
      
    }
}
