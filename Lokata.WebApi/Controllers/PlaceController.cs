﻿using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService ?? throw new System.ArgumentNullException(nameof(placeService));
        }

        [HttpGet]
        public async Task<IEnumerable<Place>> Get()
        {
            return await _placeService.GetAllWithDependencies();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> Get(int id)
        {
            var result = await _placeService.GetWithDependencies(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Place>> Post([FromBody] Place place)
        {
            await _placeService.Create(place);
            return Ok(place);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Place place)
        {
            if (id != place.Id)
            {
                return BadRequest();
            }
            var currentItem = await _placeService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(place);
            await _placeService.Update(currentItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _placeService.Delete(id);
            return Ok();
        }
    }
}
