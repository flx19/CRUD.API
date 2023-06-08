using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using one.hr.api.Models;
using one.hr.api.Services;

namespace one.hr.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IGenericCRUDService<AddressModel> _addressSvc;
        public AddressController(IGenericCRUDService<AddressModel> addressSvc)
        {
            _addressSvc = addressSvc;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _addressSvc.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Address with the given id ={id} is not found");
            else if (id < 0)
                return BadRequest("Wrong data");
            return Ok(await _addressSvc.GetById(id));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressModel address)
        {
            var created = await _addressSvc.Create(address);
            var routvalues = new { Id = created.ID };
            return CreatedAtRoute(routvalues, created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddressModel address)
        {
            var updatedepmloyee = await _addressSvc.Update(id, address);
            return Ok(updatedepmloyee);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deletedreuslt = await _addressSvc.Delete(id);
            if (deletedreuslt) return NoContent();
            else return BadRequest();
        }
    }
}
