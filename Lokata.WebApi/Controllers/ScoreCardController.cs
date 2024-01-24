using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreCardController : ControllerBase
    {
        private readonly IScoreCardService _scoreCardService;

        public ScoreCardController(IScoreCardService scoreCardService)
        {
            _scoreCardService = scoreCardService ?? throw new System.ArgumentNullException(nameof(scoreCardService));
        }

        [HttpGet]
        public async Task<IEnumerable<ScoreCard>> Get()
        {
            return await _scoreCardService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScoreCard>> Get(int id)
        {
            var result = await _scoreCardService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScoreCard scoreCard)
        {
            await _scoreCardService.Create(scoreCard);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ScoreCard scoreCard)
        {
            if (id != scoreCard.Id)
            {
                return BadRequest();
            }
            var currentItem = await _scoreCardService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(scoreCard);
            await _scoreCardService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _scoreCardService.Delete(id);
            return Ok();
        }
    }
}
