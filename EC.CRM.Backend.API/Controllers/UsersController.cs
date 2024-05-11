using EC.CRM.Backend.API.Utils;
using EC.CRM.Backend.Application.DTOs.Request.Users;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EC.CRM.Backend.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IUserService userService;
        private readonly ClaimsHelper claimsHelper;

        public UsersController(IStudentService studentService, IUserService userService, ClaimsHelper claimsHelper)
        {
            this.studentService = studentService;
            this.userService = userService;
            this.claimsHelper = claimsHelper;
        }

        [HttpPost]
        public async Task<ActionResult<UserInfoResponse>> CreateUser(CreateUserRequest createUserRequest)
        {
            var createdStudent = await userService.CreateUserAsync(createUserRequest);

            return CreatedAtAction(nameof(CreateUser), new { uid = createdStudent.Uid }, createdStudent);
        }

        public async Task<ActionResult<UserInfoResponse>> GetMe()
        {
            var userUid = claimsHelper.GetUserUid(HttpContext);

            var user = await userService.GetAsync(userUid);

            return Ok(user);
        }
    }
}
