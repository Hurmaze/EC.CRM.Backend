namespace EC.CRM.Backend.Domain.Entities
{
    public class UserInfo
    {
        public Guid Uid { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Email { get; set; }
        public decimal? CurentSalary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Paid { get; set; }
        public required Role Role { get; set; }
        public List<Job>? Jobs { get; set; }
        public Location? Location { get; set; }
    }
}
