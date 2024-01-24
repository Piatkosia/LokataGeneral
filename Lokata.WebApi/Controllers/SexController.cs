using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexController : ControllerBase
    {
        private readonly ISexService _sexService;

        public SexController(ISexService sexService)
        {
            _sexService = sexService ?? throw new System.ArgumentNullException(nameof(sexService));
        }

        [HttpGet]
        public async Task<IEnumerable<Sex>> Get()
        {
            return await _sexService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sex>> Get(int id)
        {
            var result = await _sexService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Sex sex)
        {
            await _sexService.Create(sex);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Sex sex)
        {
            if (id != sex.Id)
            {
                return BadRequest();
            }
            var currentItem = await _sexService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(sex);
            await _sexService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sexService.Delete(id);
            return Ok();
        }
    }
}
