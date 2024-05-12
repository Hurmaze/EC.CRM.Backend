namespace EC.CRM.Backend.Application.DTOs.Response
{
    public record StateResponse
    {
        public Guid Uid { get; set; }
        public required string Name { get; set; }
        public int OrderingId { get; set; }
    }
}
