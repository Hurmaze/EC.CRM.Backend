namespace EC.CRM.Backend.Domain.Entities
{
    public class Role
    {
        public Guid Uid { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public List<UserInfo>? UserInfos { get; set; }
    }
}
