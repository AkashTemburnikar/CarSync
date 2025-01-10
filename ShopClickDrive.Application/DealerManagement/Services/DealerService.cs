using ShopClickDrive.Application.DealerManagement.DTOs;
using ShopClickDrive.Core.DealerManagement.Entities;
using ShopClickDrive.Core.Exceptions;
using ShopClickDrive.Core.Interfaces;

namespace ShopClickDrive.Application.DealerManagement.Services;

public class DealerService
{
    private readonly IDealerRepository _dealerRepository;

    public DealerService(IDealerRepository dealerRepository)
    {
        _dealerRepository = dealerRepository;
    }
    
    public async Task<Dealer> CreateDealerAsync(CreateDealerDto dealerDto)
    {
        var dealer = new Dealer(dealerDto.Name, dealerDto.Email, dealerDto.Address);
        return await _dealerRepository.AddAsync(dealer);
    }

    public async Task UpdateDealerAsync(Guid id, UpdateDealerDto dealerDto)
    {
        var dealer = await GetDealerByIdAsync(id);
        dealer?.UpdateDetails(dealerDto.Name, dealerDto.Email, dealerDto.Address);
        await _dealerRepository.SaveChangesAsync();
    }

    public async Task<Dealer?> GetDealerByIdAsync(Guid id)
    {
        var dealer = await _dealerRepository.GetByIdAsync(id);
        if (dealer == null)
        {
            throw new DealerNotFoundException(id);
        }
        return dealer;
    }

    public async Task<IEnumerable<Dealer>> GetDealersAsync(DealerQueryDto queryDto)
    {
        var query =  await _dealerRepository.GetAllAsync();

        if (!string.IsNullOrEmpty(queryDto.Name))
        {
            query = query.Where(d => d.Name.Contains(queryDto.Name, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(queryDto.SortBy) && queryDto.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
        {
            query = query.OrderBy(d => d.Name);
        }

        return query.ToList();
    }
    
    public async Task DeleteDealerAsync(Guid id)
    {
        var dealer = await GetDealerByIdAsync(id);
        if (dealer != null) _dealerRepository.Remove(dealer);
        await _dealerRepository.SaveChangesAsync();
    }
}