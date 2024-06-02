namespace EC.CRM.Backend.Application.DTOs.Response
{
    public record MentorValuationResponse
    {
        public Guid MentorUid { get; set; }
        public string MentorName { get; set; }
        public bool? WasSetByMentor { get; set; }
        public double? Valuation { get; set; }

        public MentorValuationResponse(Guid mentorUid, string mentorName, double? valuation, bool? wasSetByMentor)
        {
            MentorUid = mentorUid;
            MentorName = mentorName;
            Valuation = valuation;
            WasSetByMentor = wasSetByMentor;
        }
        public MentorValuationResponse()
        {
        }
    }
}
