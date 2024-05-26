using EC.CRM.Backend.Application.DTOs.Response;

namespace EC.CRM.Backend.Application.DTOs.Request.Users
{
    public record UpdateUserRequest
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public StateResponse? State { get; set; }
        public List<Guid>? SkillsUids { get; set; }
        public List<Guid>? NonProffesionalInterestsUids { get; set; }
        public Guid LocationUid { get; set; }
        public string? Description { get; set; }
    }
}
