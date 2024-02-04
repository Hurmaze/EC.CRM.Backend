namespace EC.CRM.Backend.Application.DTOs
{
    public record StudentRequest(
        string Name,
        string Email,
        string PhoneNumber,
        Guid MentorUid);
}
