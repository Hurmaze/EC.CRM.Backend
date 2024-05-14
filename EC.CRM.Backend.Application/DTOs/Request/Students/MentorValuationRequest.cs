namespace EC.CRM.Backend.Application.DTOs.Request.Students
{
    public record MentorValuationRequest(
        Guid MentorUid,
        double Valuation)
    {
    }
}
