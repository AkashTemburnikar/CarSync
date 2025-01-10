namespace ShopClickDrive.LeadManagement.Entity;

    public class Lead
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public string CarDetails { get; set; }
        public int DealerId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Status { get; set; } = "New";
    }
