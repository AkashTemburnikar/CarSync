using ShopClickDrive.LeadManagement.DTOs;
using ShopClickDrive.LeadManagement.Entity;
using ShopClickDrive.LeadManagement.Interfaces;

namespace ShopClickDrive.LeadManagement.Services;

public class LeadService
{
    private readonly ILeadRepository _repository;

    public LeadService(ILeadRepository repository)
    {
        _repository = repository;
    }

    public async Task AddLeadAsync(CreateLeadDto leadDto)
    {
        var lead = new Lead
        {
            CustomerName = leadDto.CustomerName,
            CustomerContact = leadDto.CustomerContact,
            CarDetails = leadDto.CarDetails,
            DealerId = leadDto.DealerId,
            Timestamp = DateTime.UtcNow
        };

        await _repository.AddLeadAsync(lead);
    }

    public async Task<List<Lead>> GetLeadsByDealerIdAsync(int dealerId)
    {
        return await _repository.GetLeadsByDealerIdAsync(dealerId);
    }
}