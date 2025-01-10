namespace ShopClickDrive.Core.Exceptions;

public class DealerNotFoundException : Exception
{
    public DealerNotFoundException(Guid dealerId) : base($"Dealer with id {dealerId} was not found.")
    {
        
    }
}