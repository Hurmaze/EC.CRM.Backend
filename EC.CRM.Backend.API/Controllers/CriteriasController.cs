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
                // Do something with the parsed data, such as saving to a database
                return Ok();
            }
        }
    }
}
