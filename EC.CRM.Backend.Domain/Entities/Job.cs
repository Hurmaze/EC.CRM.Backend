namespace EC.CRM.Backend.Domain.Entities
{
    public class Job
    {
        public Guid Uid { get; set; }
        public required string CompanyName { get; set; }
        public required string PositionName { get; set; }
        public required decimal Salary { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime? EndTime { get; set; }
    }
}
