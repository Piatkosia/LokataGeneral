using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UmpireController : ControllerBase
    {
        private readonly IUmpireService _umpireService;

        public UmpireController(IUmpireService umpire)
        {
            _umpireService = umpire ?? throw new System.ArgumentNullException(nameof(umpire));
        }

        [HttpGet]
        public async Task<IEnumerable<Umpire>> Get()
        {
            return await _umpireService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Umpire>> Get(int id)
        {
            var result = await _umpireService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Umpire>> Post([FromBody] Umpire umpire)
        {
            await _umpireService.Create(umpire);
            return Ok(umpire);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Umpire umpire)
        {
            if (id != umpire.Id)
            {
                return BadRequest();
            }
            var currentItem = await _umpireService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(umpire);
            await _umpireService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _umpireService.Delete(id);
            return Ok();
        }
    }
}
