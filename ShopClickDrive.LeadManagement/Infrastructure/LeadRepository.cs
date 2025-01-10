using Microsoft.EntityFrameworkCore;
using ShopClickDrive.LeadManagement.Entity;
using ShopClickDrive.LeadManagement.Interfaces;

namespace ShopClickDrive.LeadManagement.Infrastructure;

public class LeadRepository : ILeadRepository
{
    private readonly LeadDbContext _context;

    public LeadRepository(LeadDbContext context)
    {
        _context = context;
    }

    public async Task AddLeadAsync(Lead lead)
    {
        await _context.Leads.AddAsync(lead);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Lead>> GetLeadsByDealerIdAsync(int dealerId)
    {
        return await _context.Leads.Where(x => x.DealerId == dealerId).ToListAsync();
    }
}