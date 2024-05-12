namespace EC.CRM.Backend.Application.DTOs.Response
{
    public record LocationResponse
    {
        public Guid Uid { get; set; }
        public string? Address { get; set; }
        public required string City { get; set; }
    }
}
