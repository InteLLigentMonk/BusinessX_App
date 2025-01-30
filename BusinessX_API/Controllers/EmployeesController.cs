using Business_Logic.Dtos;
using Business_Logic.Interfaces;
using Business_Logic.Models;
using BusinessX_Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BusinessX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService service) : ControllerBase
    {
        private readonly IEmployeeService _service = service;

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetContacts()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var Employee = await _service.GetAsync(c => c.Id == id);

            if (Employee == null)
            {
                return NotFound();
            }

            return Employee;
        }

        // GET: api/Employee/WithProjects/5
        [HttpGet("WithProjects/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeWithProjectsById(int id)
        {
            var contact = await _service.GetEmployeeWithProjectsAsync(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<EmployeeEntity>> AddEmployeeAsync(EmployeeRegistrationForm EmployeeRegForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdEmployee = await _service.AddAsync(EmployeeRegForm);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployeeAsync(Employee updatedEmployee, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldEmployee = await _service.GetAsync(c => c.Id == id);

            if (oldEmployee == null)
            {
                return BadRequest();
            }

            var Employee = await _service.UpdateAsync(c => c.Id == oldEmployee.Id, updatedEmployee);
            return Ok(Employee);

        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeEntity(int id)
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

