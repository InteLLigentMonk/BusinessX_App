﻿namespace Business_Logic.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int StatusId { get; set; }
    public string CustomerId { get; set; } = null!;
    public int ContactId { get; set; }
    public int ServiceId { get; set; }
    public int EmployeeId { get; set; }
}
