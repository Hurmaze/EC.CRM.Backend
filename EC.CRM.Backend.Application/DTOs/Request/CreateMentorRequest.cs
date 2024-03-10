namespace EC.CRM.Backend.Application.DTOs.Request
{
    public class CreateMentorRequest
    {
        public Guid UserInfoUid { get; set; }
        public List<Guid>? Students { get; set; }
    }
}
