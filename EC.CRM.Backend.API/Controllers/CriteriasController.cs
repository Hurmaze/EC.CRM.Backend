using EC.CRM.Backend.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EC.CRM.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriteriasController : ControllerBase
    {
        private readonly ICriteriaService criteriaService;

        public CriteriasController(ICriteriaService criteriaService)
        {
            this.criteriaService = criteriaService;
        }

        [HttpPost("register-criterias")]
        public async Task<ActionResult> RegisterCriterias(int criteriasCount, IFormFile criteriasCsv)
        {
            using (var memoryStream = new MemoryStream())
            {
                criteriasCsv.CopyTo(memoryStream);
                memoryStream.Position = 0;

                await criteriaService.RegisterCriteriasAsync(criteriasCount, memoryStream);

                return Ok();
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetCriterias()
        {
            var criterias = await criteriaService.GetCriteriasAsync();

            return Ok(criterias);
        }
    }
}
