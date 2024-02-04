namespace EC.CRM.Backend.Application.Models
{
    public class MentorResponse
    {
        public Guid Uid { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public decimal? CurentSalary { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
