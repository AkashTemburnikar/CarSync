using Microsoft.EntityFrameworkCore;
using ShopClickDrive.LeadManagement.Entity;

namespace ShopClickDrive.LeadManagement.Infrastructure;

public class LeadDbContext : DbContext
{
    public LeadDbContext(DbContextOptions<LeadDbContext> options) : base(options) { }

    public DbSet<Lead> Leads { get; set; }
}