using ApiCrudTest.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudTest.Data
{
    public class ApiTestDbContext : DbContext
    {
        public ApiTestDbContext(DbContextOptions<ApiTestDbContext> options)
       : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StoreProductMapping> StoreProductMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the primary keys and relationships
            modelBuilder.Entity<Store>()
                .HasKey(s => s.StoreID);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductID);

            modelBuilder.Entity<StoreProductMapping>()
                .HasKey(spm => spm.MappingID);

            modelBuilder.Entity<StoreProductMapping>()
                .HasOne(spm => spm.Store)
                .WithMany(s => s.StoreProductMappings)
                .HasForeignKey(spm => spm.StoreID);

            modelBuilder.Entity<StoreProductMapping>()
                .HasOne(spm => spm.Product)
                .WithMany(p => p.StoreProductMappings)
                .HasForeignKey(spm => spm.ProductID);
        }
    }
}
