namespace EC.CRM.Backend.Application.DTOs.Response
{
    public record SkillResponse
    {
        public Guid Uid { get; set; }
        public required string Name { get; set; }
    }
}
