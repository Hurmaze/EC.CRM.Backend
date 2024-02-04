namespace EC.CRM.Backend.Domain.Entities
{
    public class Student
    {
        public Guid Uid { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public decimal? CurrentSalary { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal? PaidToClub { get; set; }
        public List<Job>? Jobs { get; set; }
        public Mentor? Menthor { get; set; }
    }
}
