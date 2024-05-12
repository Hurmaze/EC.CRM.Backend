namespace EC.CRM.Backend.Application.DTOs.Response
{
    public record JobResponse
    {
        public Guid Uid { get; set; }
        public required string CompanyName { get; set; }
        public required string PositionName { get; set; }
        public required decimal Salary { get; set; }
        public required DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
