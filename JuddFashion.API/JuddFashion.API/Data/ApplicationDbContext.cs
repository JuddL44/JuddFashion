
using Microsoft.EntityFrameworkCore;
using JuddFashion.API.Models;


namespace JuddFashion.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Description).HasMaxLength(2000);
                entity.Property(p => p.BasePrice).HasColumnType("decimal(18,2)");
                entity.HasMany(p => p.Variants).WithOne(v => v.Product).HasForeignKey(v => v.ProductId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ProductVariant>(entity =>
            {
                entity.Property(v => v.SKU).IsRequired().HasMaxLength(50);
                entity.Property(v => v.Color).IsRequired().HasMaxLength(30);
                entity.Property(v => v.PriceAdjustment).HasColumnType("decimal(18,2)");
                entity.HasIndex(v => v.SKU).IsUnique();
            });
        }
    }
}
