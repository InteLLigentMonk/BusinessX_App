using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessX_Data.Entities;

public class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.Property(e => e.Id)
            .HasDefaultValueSql("nextval('\"ProjectIds\"')")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.StartDate)
            .IsRequired()
            .HasDefaultValueSql("now()");
    }
}

