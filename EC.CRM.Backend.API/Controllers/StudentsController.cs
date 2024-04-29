using EC.CRM.Backend.API.Utils;
using EC.CRM.Backend.Application.Common;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpPatch("/{studentUid:guid}")]
        [Authorize(Roles = Roles.Director)]
        public async Task<ActionResult<MatchingResponse>> ChooseMentor(Guid studentUid, [FromBody] bool assign)
        {
            var matchingResponse = await matchingService.ChooseMentorAsync(studentUid);

            if (assign)
            {
                await studentService.AssignMentorAsync(studentUid, matchingResponse.MenthorUid);
            }

            return Ok(matchingResponse);
        }

        [HttpPost("/{studentUid:guid}")]
        [Authorize(Roles = $"{Roles.Mentor}, {Roles.Director}")]
        public async Task<ActionResult> SetMentorValuation(Guid studentUid, Dictionary<Guid, double> mentorsValuations)
        {
            var userRole = claimsHelper.GetUserRole(HttpContext);

            if (userRole == Roles.Director)
            {
                await matchingService.SetMentorValuation(studentUid, mentorsValuations);
            }
            else
            {
                if (mentorsValuations.IsNullOrEmpty() || mentorsValuations.Count > 1)
                {
                    return BadRequest("Mentor can set only one valuation");
                }
                if (mentorsValuations.First().Key != claimsHelper.GetUserUid(HttpContext))
                {
                    return BadRequest("Mentor can set only his valuation");
                }

                await matchingService.SetMentorValuation(studentUid, mentorsValuations);
            }

            return Ok();
        }

        [HttpGet("/{studentUid:guid}/valuations")]
        public async Task<ActionResult> GetStudentValuations(Guid studentUid)
        {
            await matchingService.GetStudentValuations(studentUid);

            return Ok();
        }
    }
}
