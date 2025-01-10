namespace ShopClickDrive.InventoryManagement.DTOs;

public class CreateInventoryDto
{
    public string CarModel { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public Guid DealerId { get; set; }
}