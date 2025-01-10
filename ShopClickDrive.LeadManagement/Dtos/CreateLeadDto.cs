namespace ShopClickDrive.LeadManagement.DTOs;

public class CreateLeadDto
{
    public string CustomerName { get; set; }
    public string CustomerContact { get; set; }
    public string CarDetails { get; set; }
    public int DealerId { get; set; }
}