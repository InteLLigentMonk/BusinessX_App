using Microsoft.AspNetCore.Mvc;
using BusinessX_Data.Entities;
using Business_Logic.Models;
using Business_Logic.Dtos;
using Business_Logic.Interfaces;

namespace BusinessX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _service;

        public ServicesController(IServiceService service)
        {
            _service = service;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetServiceById(int id)
        {
            var Service = await _service.GetAsync(c => c.Id == id);

            if (Service == null)
            {
                return NotFound();
            }

            return Service;
        }

        // GET: api/Services/WithProjects/5
        [HttpGet("WithCustomers/{id}")]
        public async Task<ActionResult<Service>> GetServiceWithProjectsById(int id)
        {
            var Service = await _service.GetServiceWithProjectsAsync(c => c.Id == id);

            if (Service == null)
            {
                return NotFound();
            }

            return Service;
        }

        // POST: api/Services
        [HttpPost]
        public async Task<ActionResult<ServiceEntity>> AddServiceAsync(ServiceRegistrationForm ServiceRegForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdService = await _service.AddAsync(ServiceRegForm);

            return CreatedAtAction(nameof(GetServiceById), new { id = createdService.Id }, createdService);
        }

        // PUT: api/Services/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditServiceAsync(Service updatedService, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldService = await _service.GetAsync(c => c.Id == id);

            if (oldService == null)
            {
                return BadRequest();
            }

            var Service = await _service.UpdateAsync(c => c.Id == oldService.Id, updatedService);
            return Ok(Service);

        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceEntity(int id)
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

