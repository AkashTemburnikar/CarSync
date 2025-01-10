using ShopClickDrive.Core.DealerManagement.Entities;

namespace ShopClickDrive.InventoryManagement.Entity
{
    public class Inventory
    {
        public Guid Id { get; private set; }
        public string CarModel { get; private set; }
        public int Year { get; private set; }
        public decimal Price { get; private set; }
        public Guid DealerId { get; private set; } // Foreign key

        public Inventory(string carModel, int year, decimal price, Guid dealerId)
        {
            Id = Guid.NewGuid();
            CarModel = carModel;
            Year = year;
            Price = price;
            DealerId = dealerId;
        }

        public void UpdateDetails(string carModel, int year, decimal price)
        {
            CarModel = carModel;
            Year = year;
            Price = price;
        }
    }
}