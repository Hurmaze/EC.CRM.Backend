namespace EC.CRM.Backend.Domain.Entities
{
    public class NonProfessionalInterest
    {
        public Guid Uid { get; set; }
        public required string Name { get; set; }
        public List<UserInfo>? Users { get; set; }
    }
}
