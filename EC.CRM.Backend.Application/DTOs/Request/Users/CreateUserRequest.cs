using EC.CRM.Backend.Application.DTOs.Request.Students;

namespace EC.CRM.Backend.Application.DTOs.Request.Users
{
    public record CreateUserRequest(
        string Name,
        string Email,
        string Password,
        string PhoneNumber,
        List<Guid>? SkillsUids,
        List<Guid>? NonProffesionalInterestsUids,
        Guid DesiredStudyFieldUid,
        Guid LocationUid,
        string Description,
        DateTime DateOfBirth) : StudentApplicationRequest(
            Name, Email, PhoneNumber, SkillsUids, NonProffesionalInterestsUids, DesiredStudyFieldUid, LocationUid)
    {
    }
}
