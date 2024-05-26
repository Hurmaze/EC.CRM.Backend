namespace EC.CRM.Backend.Application.DTOs.Response
{
    public class MatchingResponse
    {
        public Guid MentorUid { get; set; }
        public string MentorName { get; set; }
        public double MatchingCoefficient { get; set; }
        public Dictionary<Guid, double> OtherResults { get; set; }

        public MatchingResponse(
            Guid mentorUid,
            string mentorName,
            double matchingCoefficient,
            Dictionary<Guid, double> otherResults)
        {
            MentorUid = mentorUid;
            MentorName = mentorName;
            MatchingCoefficient = matchingCoefficient;
            OtherResults = otherResults;
        }
    }
}
