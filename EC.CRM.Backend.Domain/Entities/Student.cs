namespace EC.CRM.Backend.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public Guid UserInfoUid { get; set; }
        public required UserInfo UserInfo { get; set; }
        public required Mentor Mentor { get; set; }
        public required State State { get; set; }
    }
}