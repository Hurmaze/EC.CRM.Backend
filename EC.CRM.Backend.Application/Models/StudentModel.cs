namespace EC.CRM.Backend.Application.Models
{
    public class StudentModel
    {
        public Guid Uid { get; set; }
        public Guid MentorUid { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public decimal? CurrentSalary { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal? PaidToClub { get; set; }
    }
}
