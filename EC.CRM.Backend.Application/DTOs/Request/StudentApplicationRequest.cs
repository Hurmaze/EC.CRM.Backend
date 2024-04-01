namespace EC.CRM.Backend.Application.DTOs.Request
{
    public record StudentApplicationRequest(
        string Name,
        string Email,
        string PhoneNumber,
        List<Guid>? SkillsUids,
        Guid DesiredStudyFieldUid)
    {
    }
}
