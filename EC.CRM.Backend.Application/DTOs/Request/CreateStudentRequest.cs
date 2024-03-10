using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.DTOs.Request
{
    public class CreateStudentRequest
    {
        public Guid MentorUid { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required Role Role { get; set; }
        public Location? Location { get; set; }
    }
}
