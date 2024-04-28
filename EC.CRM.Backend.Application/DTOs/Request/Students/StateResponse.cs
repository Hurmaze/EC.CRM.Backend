namespace EC.CRM.Backend.Application.DTOs.Request.Students
{
    public record StateResponse
    {
        public Guid Uid { get; set; }
        public required string Name { get; set; }
    }
}
