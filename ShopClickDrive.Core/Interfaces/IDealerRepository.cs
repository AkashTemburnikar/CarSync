using ShopClickDrive.Core.DealerManagement.Entities;

namespace ShopClickDrive.Core.Interfaces;

public interface IDealerRepository
{
    Task<Dealer> AddAsync(Dealer dealer);
    Task<Dealer?> GetByIdAsync(Guid id);
    Task<IEnumerable<Dealer>> GetAllAsync();
    void Remove(Dealer dealer);
    Task SaveChangesAsync();
}