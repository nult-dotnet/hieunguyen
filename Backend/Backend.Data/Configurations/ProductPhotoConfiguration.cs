﻿using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class ProductPhotoConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.ToTable("ProductPhoto");

            builder.HasKey(x => x.ModelId);

            builder.Property(x => x.ModelId)
                .UseIdentityColumn();

            builder.Property(x => x.Url)
                .IsRequired(false);

            builder.Property(x => x.IsDefault)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductPhotos)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
