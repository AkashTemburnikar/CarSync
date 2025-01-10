using Microsoft.EntityFrameworkCore;
using ShopClickDrive.Core.DealerManagement.Entities;

namespace ShopClickDrive.Infrastructure.Data.DealerManagement
{
    public class DealerDbContext : DbContext
    {
        public DealerDbContext(DbContextOptions<DealerDbContext> options) : base(options) { }

        public DbSet<Dealer> Dealers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dealer>(entity =>
            {
                entity.Property(d => d.Id).IsRequired();
                entity.Property(d => d.Name).IsRequired().HasMaxLength(100);
                entity.Property(d => d.Email).IsRequired().HasMaxLength(100);
                entity.Property(d => d.Address).IsRequired().HasMaxLength(200);
            });
        }
    }
}