using Business_Logic.Dtos;
using Business_Logic.Interfaces;
using Business_Logic.Models;
using BusinessX_Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BusinessX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController(IStatusService service) : ControllerBase
    {
        private readonly IStatusService _service = service;

        // GET: api/Statuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/Statuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatusByName(string name)
        {
            var Status = await _service.GetAsync(c => c.Name == name);

            if (Status == null)
            {
                return NotFound();
            }

            return Status;
        }

        // POST: api/Statuses
        [HttpPost]
        public async Task<ActionResult<StatusEntity>> AddStatusAsync(StatusRegistrationForm StatusRegForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdStatus = await _service.AddAsync(StatusRegForm);

            return CreatedAtAction(nameof(GetStatusByName), new { id = createdStatus.Id }, createdStatus);
        }

        // PUT: api/Statuses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStatusAsync(Status updatedStatus, string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldStatus = await _service.GetAsync(c => c.Name == name);

            if (oldStatus == null)
            {
                return BadRequest();
            }

            var Status = await _service.UpdateAsync(c => c.Id == oldStatus.Id, updatedStatus);
            return Ok(Status);

        }

        // DELETE: api/Statuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusEntity(int id)
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
