using EC.CRM.Backend.Domain.Entities.TOPSIS;

namespace EC.CRM.Backend.Domain.Entities
{
    public class Mentor
    {
        public int Id { get; set; }
        public Guid UserInfoUid { get; set; }
        public required UserInfo UserInfo { get; set; }
        public List<Student>? Students { get; set; }
        public List<MentorValuation>? MentorValuations { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
    }
}
