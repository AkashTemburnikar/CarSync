using ShopClickDrive.LeadManagement.Entity;

namespace ShopClickDrive.LeadManagement.Interfaces;

public interface ILeadRepository
{
    Task AddLeadAsync(Lead lead);
    Task<List<Lead>> GetLeadsByDealerIdAsync(int dealerId);
}