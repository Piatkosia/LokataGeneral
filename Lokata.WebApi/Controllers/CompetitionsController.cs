using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsController : ControllerBase
    {
        private readonly ICompetitionsService _competitionsService;

        public CompetitionsController(ICompetitionsService competitionsService)
        {
            _competitionsService = competitionsService ?? throw new System.ArgumentNullException(nameof(competitionsService));
        }
        [HttpGet]
        public async Task<IEnumerable<Competitions>> Get()
        {
            return await _competitionsService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Competitions>> Get(int id)
        {
            var result = await _competitionsService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Competition>> Post([FromBody] Competitions competitions)
        {
            await _competitionsService.Create(competitions);
            return Ok(competitions);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Competitions competitions)
        {
            if (id != competitions.Id)
            {
                return BadRequest();
            }
            var currentItem = await _competitionsService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(competitions);
            await _competitionsService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _competitionsService.Delete(id);
            return Ok();
        }
    }
}