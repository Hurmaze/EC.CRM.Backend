using EC.CRM.Backend.Application.DTOs.Request.Auth;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> GetTokenAsync(LoginRequest loginRequest);
        Task ChangePasswordAsync(Guid userUid, ChangePasswordRequest changePasswordRequest);
    }
}
