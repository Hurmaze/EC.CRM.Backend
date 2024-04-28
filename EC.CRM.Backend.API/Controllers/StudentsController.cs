using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
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

        public StudentsController(IStudentService studentService, IMatchingService matchingService)
        {
            this.studentService = studentService;
            this.matchingService = matchingService;
        }

        [HttpPost("/{studentUid: Guid}")]
        public async Task<ActionResult<MatchingResponse>> ChooseMentor(Guid studentUid, [FromBody] bool assign)
        {
            var matchingResponse = await matchingService.ChooseMentorAsync(studentUid);

            if (assign)
            {
                await studentService.AssignMentorAsync(studentUid, matchingResponse.MenthorUid);
            }

            return Ok(matchingResponse);
        }

        [HttpPut("/{studentUid: Guid}")]
        public async Task<ActionResult> SetMentorValuation(Guid studentUid, Dictionary<Guid, double> mentorsValuations)
        {
            await matchingService.SetMentorValuation(studentUid, mentorsValuations);

            return Ok();
        }

        [HttpGet("/{studentUid: Guid}/valuations")]
        public async Task<ActionResult> GetStudentValuations(Guid studentUid)
        {
            await matchingService.GetStudentValuations(studentUid);

            return Ok();
        }
    }
}
