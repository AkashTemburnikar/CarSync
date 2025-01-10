using ShopClickDrive.InventoryManagement.Entity;

namespace ShopClickDrive.InventoryManagement.Interfaces;

public interface IInventoryRepository
{
    Task<Inventory> AddAsync(Inventory inventory);
    Task<IEnumerable<Inventory>> GetByDealerIdAsync(Guid dealerId);
    Task<Inventory?> GetByIdAsync(Guid id);
    void Remove(Inventory inventory);
}