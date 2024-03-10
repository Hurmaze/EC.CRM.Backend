using EC.CRM.Backend.Application.DTOs.Request;
using EC.CRM.Backend.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EC.CRM.Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> GetToken(LoginRequest loginRequest)
        {
            var token = await authService.GetTokenAsync(loginRequest);

            return Ok(new { token = token });
        }
    }
}
