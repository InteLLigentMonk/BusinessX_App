   using Microsoft.EntityFrameworkCore;
   using Microsoft.EntityFrameworkCore.Metadata.Builders;

   namespace BusinessX_Data.Entities;

   public class ContactConfiguration : IEntityTypeConfiguration<ContactEntity>
   {
       public void Configure(EntityTypeBuilder<ContactEntity> builder)
       {
           builder.Property(c => c.Email)
               .IsRequired();

           builder.HasIndex(c => c.Email)
               .IsUnique();
       }
   }
   


