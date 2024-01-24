using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetsOrCardTakeController : ControllerBase
    {
        private readonly ITargetsOrCardTakeService _targetsOrCardTakeService;

        public TargetsOrCardTakeController(ITargetsOrCardTakeService targetsOrCardTakeService)
        {
            _targetsOrCardTakeService = targetsOrCardTakeService ?? throw new System.ArgumentNullException(nameof(targetsOrCardTakeService));
        }

        [HttpGet]
        public async Task<IEnumerable<TargetsOrCardTake>> Get()
        {
            return await _targetsOrCardTakeService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TargetsOrCardTake>> Get(int id)
        {
            var result = await _targetsOrCardTakeService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TargetsOrCardTake targetsOrCardTake)
        {
            await _targetsOrCardTakeService.Create(targetsOrCardTake);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TargetsOrCardTake targetsOrCardTake)
        {
            if (id != targetsOrCardTake.Id)
            {
                return BadRequest();
            }
            var currentItem = await _targetsOrCardTakeService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(targetsOrCardTake);
            await _targetsOrCardTakeService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _targetsOrCardTakeService.Delete(id);
            return Ok();
        }
    }
}
