using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorDocumentController : ControllerBase
    {
        private readonly IInstructorDocumentService _instructorDocumentService;

        public InstructorDocumentController(IInstructorDocumentService instructorDocumentService)
        {
            _instructorDocumentService = instructorDocumentService;
        }

        [HttpGet]
        public async Task<IEnumerable<InstructorDocument>> Get()
        {
            return await _instructorDocumentService.GetAllWithDependencies();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorDocument>> Get(int id)
        {
            var result = await _instructorDocumentService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<InstructorDocument>> Post([FromBody] InstructorDocument instructorDocument)
        {
            await _instructorDocumentService.Create(instructorDocument);
            return Ok(instructorDocument);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] InstructorDocument instructorDocument)
        {
            if (id != instructorDocument.Id)
            {
                return BadRequest();
            }
            var currentItem = await _instructorDocumentService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(instructorDocument);
            await _instructorDocumentService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _instructorDocumentService.Delete(id);
            return Ok();
        }

    }
}
