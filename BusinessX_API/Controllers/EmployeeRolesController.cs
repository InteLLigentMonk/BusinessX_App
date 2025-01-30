using Microsoft.AspNetCore.Mvc;
using BusinessX_Data.Entities;
using Business_Logic.Models;
using Business_Logic.Dtos;
using Business_Logic.Interfaces;

namespace BusinessX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRolesController : ControllerBase
    {
        private readonly IEmployeeRoleService _service;

        public EmployeeRolesController(IEmployeeRoleService service)
        {
            _service = service;
        }

        // GET: api/EmployeeRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeRole>>> GetEmployeeRoles()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/EmployeeRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeRole>> GetEmployeeRoleById(int id)
        {
            var EmployeeRole = await _service.GetAsync(c => c.Id == id);

            if (EmployeeRole == null)
            {
                return NotFound();
            }

            return EmployeeRole;
        }

        // GET: api/EmployeeRoles/WithCustomers/5
        [HttpGet("WithCustomers/{id}")]
        public async Task<ActionResult<EmployeeRole>> GetEmployeeRoleWithCustomersById(int id)
        {
            var EmployeeRole = await _service.GetEmployeeRoleWithEmployeesAsync(c => c.Id == id);

            if (EmployeeRole == null)
            {
                return NotFound();
            }

            return EmployeeRole;
        }

        // POST: api/EmployeeRoles
        [HttpPost]
        public async Task<ActionResult<EmployeeRolesEntity>> AddEmployeeRoleAsync(EmployeeRoleRegistrationForm EmployeeRoleRegForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdEmployeeRole = await _service.AddAsync(EmployeeRoleRegForm);

            return CreatedAtAction(nameof(GetEmployeeRoleById), new { id = createdEmployeeRole.Id }, createdEmployeeRole);
        }

        // PUT: api/EmployeeRoles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployeeRoleAsync(EmployeeRole updatedEmployeeRole, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldEmployeeRole = await _service.GetAsync(c => c.Id == id);

            if (oldEmployeeRole == null)
            {
                return BadRequest();
            }

            var EmployeeRole = await _service.UpdateAsync(c => c.Id == oldEmployeeRole.Id, updatedEmployeeRole);
            return Ok(EmployeeRole);

        }

        // DELETE: api/EmployeeRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeRoleEntity(int id)
        {
            var exists = await _service.ExistsAsync(c => c.Id == id);
            if (exists == false)
            {
                return NotFound();
            }

            var response = await _service.RemoveAsync(c => c.Id == id);

            return Ok();
        }
    }
}
