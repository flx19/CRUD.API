using Microsoft.AspNetCore.Mvc;
using one.hr.api.Models;
using one.hr.api.Services;

namespace one.hr.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericCRUDService<EmployeeModel> _employeeSvc;
        public EmployeeController(IGenericCRUDService<EmployeeModel> employeeRepository) 
        { 
           _employeeSvc = employeeRepository;
        }
      
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeSvc.GetAll());
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"employee with the given id ={id} is not found");
            else if (id < 0)
                return BadRequest("Wrong data");
            return Ok( await _employeeSvc.GetById(id));
        }

       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeModel employee)
        {
            var created = await _employeeSvc.Create(employee);
            var routvalues = new {Id = created.Id};
            return CreatedAtRoute(routvalues,created);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeModel employee)
        {
            var updatedepmloyee = await _employeeSvc.Update(id, employee);
            return Ok(updatedepmloyee);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deletedreuslt = await _employeeSvc.Delete(id);
            if (deletedreuslt) return NoContent();
            else return BadRequest();
        }
    }
}
