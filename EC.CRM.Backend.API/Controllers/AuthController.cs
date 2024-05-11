using EC.CRM.Backend.API.Utils;
using EC.CRM.Backend.Application.DTOs.Request.Auth;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EC.CRM.Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly ClaimsHelper claimsHelper;
        public AuthController(IAuthService authService, ClaimsHelper claimsHelper)
        {
            this.authService = authService;
            this.claimsHelper = claimsHelper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> GetToken(LoginRequest loginRequest)
        {
            var token = await authService.GetTokenAsync(loginRequest);

            return Ok(new AuthResponse { Token = token });
        }

        [Authorize]
        [HttpPatch("change-password")]
        public async Task<ActionResult> ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            var userId = claimsHelper.GetUserUid(HttpContext);

            await authService.ChangePasswordAsync(userId, changePasswordRequest);

            return Ok();
        }
    }
}
