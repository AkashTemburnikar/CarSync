namespace ShopClickDrive.Core.DealerManagement.Entities
{
    public class Dealer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }

        // Constructor for creating a new Dealer
        public Dealer(string name, string email, string address)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }
        
        public void UpdateDetails(string name, string email, string address)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        private Dealer() { }
    }
}