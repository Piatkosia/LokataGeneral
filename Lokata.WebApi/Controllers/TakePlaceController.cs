using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakePlaceController : ControllerBase
    {
        private readonly ITakePlaceService _takePlaceService;

        public TakePlaceController(ITakePlaceService takePlaceService)
        {
            _takePlaceService = takePlaceService ?? throw new System.ArgumentNullException(nameof(takePlaceService));
        }

        [HttpGet]
        public async Task<IEnumerable<TakePlace>> Get()
        {
            return await _takePlaceService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TakePlace>> Get(int id)
        {
            var result = await _takePlaceService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TakePlace takePlace)
        {
            await _takePlaceService.Create(takePlace);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TakePlace takePlace)
        {
            if (id != takePlace.Id)
            {
                return BadRequest();
            }
            var currentItem = await _takePlaceService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(takePlace);
            await _takePlaceService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _takePlaceService.Delete(id);
            return Ok();
        }
    }
}
