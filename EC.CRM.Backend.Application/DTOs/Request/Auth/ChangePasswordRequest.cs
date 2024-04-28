namespace EC.CRM.Backend.Application.DTOs.Request.Auth
{
    public record ChangePasswordRequest(string OldPassword, string NewPassword)
    {
    }
}
