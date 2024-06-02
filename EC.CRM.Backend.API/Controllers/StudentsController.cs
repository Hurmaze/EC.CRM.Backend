using EC.CRM.Backend.API.Utils;
using EC.CRM.Backend.Application.Common;
using EC.CRM.Backend.Application.DTOs.Request.Students;
using EC.CRM.Backend.Application.DTOs.Request.Users;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EC.CRM.Backend.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IMatchingService matchingService;
        private readonly ClaimsHelper claimsHelper;

        public StudentsController(IStudentService studentService, IMatchingService matchingService, ClaimsHelper claimsHelper)
        {
            this.studentService = studentService;
            this.matchingService = matchingService;
            this.claimsHelper = claimsHelper;
        }

        [HttpPatch("{studentUid:guid}")]
        [Authorize(Roles = Roles.Director)]
        public async Task<ActionResult<MatchingResponse>> ChooseMentor(Guid studentUid, [FromBody] bool assign)
        {
            var matchingResponse = await matchingService.ChooseMentorAsync(studentUid);

            if (assign)
            {
                await studentService.AssignMentorAsync(studentUid, matchingResponse.MentorUid);
            }

            return Ok(matchingResponse);
        }

        [HttpPost("{studentUid:guid}/valuations")]
        [Authorize(Roles = $"{Roles.Mentor}, {Roles.Director}")]
        public async Task<ActionResult> SetMentorValuation(Guid studentUid, List<MentorValuationRequest> mentorsValuations)
        {
            var userRole = claimsHelper.GetUserRole(HttpContext);

            if (userRole == Roles.Director)
            {
                await matchingService.SetMentorValuationAsync(studentUid, mentorsValuations, false);
            }
            else
            {
                if (mentorsValuations.IsNullOrEmpty() || mentorsValuations.Count > 1)
                {
                    return BadRequest("Mentor can set only one valuation");
                }
                if (mentorsValuations.First().MentorUid != claimsHelper.GetUserUid(HttpContext))
                {
                    return BadRequest("Mentor can set only his valuation");
                }

                await matchingService.SetMentorValuationAsync(studentUid, mentorsValuations, true);
            }

            return Ok();
        }

        [HttpGet("{studentUid:guid}/valuations")]
        public async Task<ActionResult<List<MentorValuationResponse>>> GetStudentValuations(Guid studentUid)
        {
            var valuations = await matchingService.GetStudentValuationsAsync(studentUid);

            return Ok(valuations);
        }

        [HttpGet("application")]
        public async Task<ActionResult<List<StudentResponse>>> GetStudentsApplications()
        {
            var students = await studentService.GetAllApplicationAsync();

            return Ok(students);
        }

        [HttpPost("application")]
        [AllowAnonymous]
        public async Task<ActionResult<StudentResponse>> CreateStudentApplication(StudentApplicationRequest studentApplicationRequest)
        {
            var createdStudent = await studentService.CreateAsync(studentApplicationRequest);

            return CreatedAtAction(nameof(CreateStudentApplication), new { uid = createdStudent.Uid }, createdStudent);
        }

        [Authorize]
        [HttpGet("{studentUid:guid}")]
        public async Task<ActionResult<StudentResponse>> GetStudent(Guid studentUid)
        {
            var student = await studentService.GetAsync(studentUid);

            return Ok(student);
        }

        [Authorize]
        [HttpPut("{studentUid:guid}")]
        public async Task<ActionResult> UpdateStudent(Guid studentUid, UpdateUserRequest requestBody)
        {
            await studentService.UpdateAsync(studentUid, requestBody);

            return Ok();
        }
    }
}
