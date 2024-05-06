namespace EC.CRM.Backend.Application.DTOs.Response
{
    public record AuthResponse
    {
        public required string Token { get; init; }
    }
}
