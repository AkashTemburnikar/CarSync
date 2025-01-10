using Microsoft.EntityFrameworkCore;
using ShopClickDrive.InventoryManagement.Entity;
using ShopClickDrive.InventoryManagement.Interfaces;

namespace ShopClickDrive.InventoryManagement.Infrastructure;

public class InventoryRepository : IInventoryRepository
{
    private readonly InventoryDbContext _inventoryDbContext;

    public InventoryRepository(InventoryDbContext inventoryDbContext)
    {
        _inventoryDbContext = inventoryDbContext;
    }

    public async Task<Inventory> AddAsync(Inventory inventory)
    {
        _inventoryDbContext.Inventories.Add(inventory);
        await _inventoryDbContext.SaveChangesAsync();
        return inventory;
    }

    public async Task<IEnumerable<Inventory>> GetByDealerIdAsync(Guid dealerId)
    {
        return await _inventoryDbContext.Inventories
            .Where(i => i.DealerId == dealerId)
            .ToListAsync();
    }

    public async Task<Inventory?> GetByIdAsync(Guid id)
    {
        return await _inventoryDbContext.Inventories.FindAsync(id);
    }

    public void Remove(Inventory inventory)
    {
        _inventoryDbContext.Inventories.Remove(inventory);
    }
}
