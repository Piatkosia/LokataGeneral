using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetsAndCardsPhotoController : ControllerBase
    {
        private readonly ITargetsAndCardsPhotoService _targetsAndCardsPhotoService;

        public TargetsAndCardsPhotoController(ITargetsAndCardsPhotoService targetsAndCardsPhotoService)
        {
            _targetsAndCardsPhotoService = targetsAndCardsPhotoService ?? throw new System.ArgumentNullException(nameof(targetsAndCardsPhotoService));
        }

        [HttpGet]
        public async Task<IEnumerable<TargetsAndCardsPhoto>> Get()
        {
            return await _targetsAndCardsPhotoService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TargetsAndCardsPhoto>> Get(int id)
        {
            var result = await _targetsAndCardsPhotoService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TargetsAndCardsPhoto targetsAndCardsPhoto)
        {
            await _targetsAndCardsPhotoService.Create(targetsAndCardsPhoto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TargetsAndCardsPhoto targetsAndCardsPhoto)
        {
            if (id != targetsAndCardsPhoto.Id)
            {
                return BadRequest();
            }
            var currentItem = await _targetsAndCardsPhotoService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(targetsAndCardsPhoto);
            await _targetsAndCardsPhotoService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _targetsAndCardsPhotoService.Delete(id);
            return Ok();
        }
    }
}
