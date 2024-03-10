namespace EC.CRM.Backend.Domain.Entities
{
    public class Credentials
    {
        public Guid UserInfoUid { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
        public UserInfo? User { get; set; }
    }
}
