using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionService _competitionService;

        public CompetitionController(ICompetitionService competitionService)
        {
            _competitionService = competitionService ?? throw new System.ArgumentNullException(nameof(competitionService));
        }

        [HttpGet]
        public async Task<IEnumerable<Competition>> Get()
        {
            return await _competitionService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Competition>> Get(int id)
        {
            var result = await _competitionService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Competition competition)
        {
            await _competitionService.Create(competition);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Competition competition)
        {
            if (id != competition.Id)
            {
                return BadRequest();
            }
            var currentItem = await _competitionService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(competition);
            await _competitionService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _competitionService.Delete(id);
            return Ok();
        }
    }
}
