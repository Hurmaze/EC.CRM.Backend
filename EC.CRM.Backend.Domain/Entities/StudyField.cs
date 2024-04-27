namespace EC.CRM.Backend.Domain.Entities
{
    public class StudyField
    {
        public Guid Uid { get; set; }
        public required string Name { get; set; }
        public List<UserInfo>? Users { get; set; }
    }
}
