using EC.CRM.Backend.Application.DTOs.Request;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<string> GetTokenAsync(LoginRequest loginRequest);
    }
}
