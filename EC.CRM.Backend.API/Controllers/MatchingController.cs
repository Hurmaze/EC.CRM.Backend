using EC.CRM.Backend.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EC.CRM.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchingController : ControllerBase
    {
        private readonly IMatchingService matchingService;

        public MatchingController(IMatchingService matchingService)
        {
            this.matchingService = matchingService;
        }

        [HttpPost("find-mentor")]
        public async Task<ActionResult> FindMentor(Guid studentUid)
        {
            var matchingResult = await matchingService.ChooseMentorAsync(studentUid);

            return Ok(matchingResult);
        }
    }
}
