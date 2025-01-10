using ShopClickDrive.InventoryManagement.DTOs;
using ShopClickDrive.InventoryManagement.Entity;
using ShopClickDrive.InventoryManagement.Interfaces;

namespace ShopClickDrive.InventoryManagement.Services;

public class InventoryService
{
    private readonly IInventoryRepository _repository;

    public InventoryService(IInventoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Inventory> CreateAsync(CreateInventoryDto dto)
    {
        var inventory = new Inventory(dto.CarModel, dto.Year, dto.Price, dto.DealerId);
        return await _repository.AddAsync(inventory);
    }

    public async Task<IEnumerable<Inventory>> GetByDealerIdAsync(Guid dealerId)
    {
        return await _repository.GetByDealerIdAsync(dealerId);
    }

    public async Task<Inventory?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
