using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Alias)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnType("Date");

            builder.Property(x => x.ModifiedDate)
                .HasColumnType("Date")
                .IsRequired(false);

            builder.Property(x => x.CreatedBy)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.ModifiedBy)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.HasOne(x => x.ProductType)
                 .WithMany(x => x.Categories)
                 .HasForeignKey(x => x.ProductTypeId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
