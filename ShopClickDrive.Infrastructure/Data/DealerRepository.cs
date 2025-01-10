using Microsoft.EntityFrameworkCore;
using ShopClickDrive.Core.DealerManagement.Entities;
using ShopClickDrive.Core.Interfaces;
using ShopClickDrive.Infrastructure.Data.DealerManagement;

namespace ShopClickDrive.Infrastructure.Data
{
    public class DealerRepository(DealerDbContext dbContext) : IDealerRepository
    {
        public async Task<Dealer> AddAsync(Dealer dealer)
        {
            await dbContext.Dealers.AddAsync(dealer);
            await dbContext.SaveChangesAsync();
            return dealer;
        }

        public async Task<Dealer?> GetByIdAsync(Guid id)
        {
            return await dbContext.Dealers.FirstOrDefaultAsync(dealer => dealer.Id == id) ?? null;
        }

        public async Task<IEnumerable<Dealer>> GetAllAsync()
        {
            return await dbContext.Dealers.ToListAsync();
        }

        public void Remove(Dealer dealer)
        {
            dbContext.Dealers.Remove(dealer);
        }

        public async Task SaveChangesAsync()
        { 
            await dbContext.SaveChangesAsync();
        }
    }
}