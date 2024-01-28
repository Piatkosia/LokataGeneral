using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lokata.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService ?? throw new System.ArgumentNullException(nameof(addressService));
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<IEnumerable<Address>> Get()
        {
            return await _addressService.GetAllAsync();
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Get(int id)
        {
            var result = await _addressService.GetById(id);
            return Ok(result);
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task<ActionResult<Address>> Post([FromBody] Address address)
        {
            await _addressService.Create(address);
            return Ok(address);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }
            var currentItem = await _addressService.GetById(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.CopyProperties(address);
            await _addressService.Update(currentItem);
            return Ok();
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _addressService.Delete(id);
            return Ok();
        }
    }
}
