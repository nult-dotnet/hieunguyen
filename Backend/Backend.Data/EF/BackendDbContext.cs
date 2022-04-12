using Backend.Data.Configurations;
using Backend.Data.Entities;
using Backend.Data.Extensions;
using Backend.Data.MultipleProviderHandle;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.EF
{
    public class BackendDbContext : DbContext
    {
        public BackendDbContext(DbContextOptions options) : base(options) { }

        public BackendDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            Instance.GetInstance().OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPhotoConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());

            modelBuilder.Seed();
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhotos { get; set; }
    }
}
