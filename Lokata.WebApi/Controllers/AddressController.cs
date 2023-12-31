using Lokata.Domain;
using Lokata.Domain.Services;
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
            _addressService = addressService;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<IEnumerable<Address>> Get()
        {
            return await _addressService.GetAllAsync();
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<Address> Get(int id)
        {
            return await _addressService.GetById(id);
        }

        // POST api/<AddressController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _addressService.Delete(id);
        }
    }
}
