namespace EC.CRM.Backend.Application.DTOs.Response
{
    public record StudentResponse : UserInfoResponse
    {
        public required StateResponse State { get; set; }
        public List<MentorValuationResponse>? MentorValuations { get; set; }
    }
}
