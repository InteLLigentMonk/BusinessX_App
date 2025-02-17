using BusinessX_Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace BusinessX_Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    
    public DbSet<ContactEntity> Contacts { get; set; }

    public DbSet<EmployeeRolesEntity> EmployeeRoles { get; set; }

    public DbSet<ServiceEntity> Services { get; set; }

    public DbSet<EmployeeEntity> Employees { get; set; }

    public DbSet<CustomerEntity> Customers { get; set; }

    public DbSet<ProjectEntity> Projects { get; set; }

    public DbSet<StatusEntity> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Customer)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => new { p.CustomerId, p.ContactId });

        modelBuilder.Entity<CustomerEntity>()
            .HasKey(c => new { c.Name, c.ContactId });

        modelBuilder.HasSequence<int>("ProjectIds")
            .StartsAt(101)
            .IncrementsBy(1);

        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new ContactConfiguration());

    }
}

