namespace EC.CRM.Backend.Application.DTOs.Request.Students
{
    public record StudentApplicationRequest(
        string Name,
        string Email,
        string PhoneNumber,
        List<Guid>? SkillsUids,
        List<Guid>? NonProffesionalInterestsUids,
        Guid DesiredStudyFieldUid,
        Guid LocationUid)
    {
    }
}
