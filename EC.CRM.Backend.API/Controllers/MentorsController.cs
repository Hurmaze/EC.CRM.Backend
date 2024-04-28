using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EC.CRM.Backend.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly IMentorService mentorService;

        public MentorsController(IMentorService mentorService)
        {
            this.mentorService = mentorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentorResponse>>> GetMentors()
        {
            var mentors = await mentorService.GetAllAsync();

            return Ok(mentors);
        }

        [HttpGet("/{userUid: Guid}")]
        public async Task<ActionResult<MentorResponse>> GetMentor(Guid userUid)
        {
            var mentor = await mentorService.GetAsync(userUid);

            return Ok(mentor);
        }

        [HttpPost("/{userUid: Guid}")]
        public async Task<ActionResult> CreateMentor(Guid userUid)
        {
            await mentorService.CreateAsync(userUid);

            return Ok();
        }
    }
}
