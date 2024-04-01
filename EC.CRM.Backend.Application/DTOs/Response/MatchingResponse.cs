namespace EC.CRM.Backend.Application.DTOs.Response
{
    public class MatchingResponse
    {
        public Guid MenthorUid { get; set; }
        public double MatchingCoefficient { get; set; }
        public required Dictionary<Guid, double> OtherResults { get; set; }
    }
}
