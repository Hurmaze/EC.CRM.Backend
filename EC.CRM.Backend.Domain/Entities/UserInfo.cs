namespace EC.CRM.Backend.Domain.Entities
{
    public class UserInfo
    {
        public Guid Uid { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Email { get; set; }
        public decimal? CurrentSalary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public decimal Paid { get; set; }
        public Guid RoleUid { get; set; }
        public required Role Role { get; set; }
        public List<Job>? Jobs { get; set; }
        public required List<Skill> Skills { get; set; }
        public List<NonProfessionalInterest>? NonProfessionalInterests { get; set; }
        public required List<Location> Locations { get; set; }
        public required List<StudyField> StudyFields { get; set; }
        public Mentor? MentorProperties { get; set; }
        public Student? StudentProperties { get; set; }
        public required Credentials Credentials { get; set; }
    }
}
