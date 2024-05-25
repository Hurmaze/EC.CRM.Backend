namespace EC.CRM.Backend.Application.DTOs.Response
{
    public record MentorValuationResponse
    {
        public Guid MentorUid { get; set; }
        public string MentorName { get; set; }
        public double? Valuation { get; set; }

        public MentorValuationResponse(Guid mentorUid, string mentorName, double? valuation)
        {
            MentorUid = mentorUid;
            MentorName = mentorName;
            Valuation = valuation;
        }
        public MentorValuationResponse()
        {
        }
    }
}
