namespace EC.CRM.Backend.Domain.Entities
{
    public class Location
    {
        public Guid Uid { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public List<UserInfo> Users { get; set; } = new();
    }
}
