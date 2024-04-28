using EC.CRM.Backend.Application.DTOs.Request.Students;
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

        public UsersController(IStudentService studentService, IUserService userService)
        {
            this.studentService = studentService;
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserInfoResponse>> CreateUser(CreateUserRequest createuserRequest)
        {
            var createdStudent = await userService.CreateUserAsync(createuserRequest);

            return CreatedAtAction(nameof(CreateStudentApplication), new { uid = createdStudent.Uid }, createdStudent);
        }

        [HttpPost("/application")]
        [AllowAnonymous]
        public async Task<ActionResult<StudentResponse>> CreateStudentApplication(StudentApplicationRequest studentApplicationRequest)
        {
            var createdStudent = await studentService.CreateAsync(studentApplicationRequest);

            return CreatedAtAction(nameof(CreateStudentApplication), new { uid = createdStudent.Uid }, createdStudent);
        }
    }
}
