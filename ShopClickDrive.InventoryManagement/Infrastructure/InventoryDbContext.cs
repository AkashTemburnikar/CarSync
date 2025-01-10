using Microsoft.EntityFrameworkCore;
using ShopClickDrive.InventoryManagement.Entity;

namespace ShopClickDrive.InventoryManagement.Infrastructure
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(i => i.Id).IsRequired();
                entity.Property(i => i.CarModel).IsRequired().HasMaxLength(100);
                entity.Property(i => i.Year).IsRequired();
                entity.Property(i => i.Price).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(i => i.DealerId).IsRequired(); // Just the foreign key
            });
        }
    }
}