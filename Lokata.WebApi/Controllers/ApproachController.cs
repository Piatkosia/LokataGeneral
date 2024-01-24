using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproachController : ControllerBase
    {
        private readonly IApproachService _approachService;

        public ApproachController(IApproachService approachService)
        {
            _approachService = approachService ?? throw new System.ArgumentNullException(nameof(approachService));
        }

        [HttpGet]
        public async Task<IEnumerable<Approach>> Get()
        {
            return await _approachService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Approach>> Get(int id)
        {
            var result = await _approachService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Approach approach)
        {
            await _approachService.Create(approach);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Approach approach)
        {
            if (id != approach.Id)
            {
                return BadRequest();
            }
            var currentItem = await _approachService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(approach);
            await _approachService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _approachService.Delete(id);
            return Ok();
        }
    }
}
