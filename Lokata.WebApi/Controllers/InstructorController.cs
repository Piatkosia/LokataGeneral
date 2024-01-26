using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService ?? throw new System.ArgumentNullException(nameof(instructorService));
        }

        [HttpGet]
        public async Task<IEnumerable<Instructor>> Get()
        {
            return await _instructorService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Instructor>> Get(int id)
        {
            var result = await _instructorService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Instructor instructor)
        {
            await _instructorService.Create(instructor);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Instructor instructor)
        {
            if (id != instructor.Id)
            {
                return BadRequest();
            }
            var currentItem = await _instructorService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(instructor);
            await _instructorService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _instructorService.Delete(id);
            return Ok();
        }
    }
}
