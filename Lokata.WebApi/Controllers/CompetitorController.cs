using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private readonly ICompetitorService _competitorService;

        public CompetitorController(ICompetitorService competitorService)
        {
            _competitorService = competitorService ?? throw new System.ArgumentNullException(nameof(competitorService));
        }

        [HttpGet]
        public async Task<IEnumerable<Competitor>> Get()
        {
            return await _competitorService.GetAllAsync();
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Competitor>> Get(int id)
        {
            var result = await _competitorService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Competitor competitor)
        {
            await _competitorService.Create(competitor);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Competitor competitor)
        {
            if (id != competitor.Id)
            {
                return BadRequest();
            }
            var currentItem = await _competitorService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(competitor);
            await _competitorService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _competitorService.Delete(id);
            return Ok();
        }
    }
}
