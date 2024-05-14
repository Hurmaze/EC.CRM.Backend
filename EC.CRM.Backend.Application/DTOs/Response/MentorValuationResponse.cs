namespace EC.CRM.Backend.Application.DTOs.Response
{
    public record MentorValuationResponse(
        Guid MentorUid,
        string MentorName,
        double? Valuation)
    {
    }
}
