using Business_Logic.Dtos;
using Business_Logic.Interfaces;
using Business_Logic.Models;
using BusinessX_Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BusinessX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService service) : ControllerBase
    {
        private readonly ICustomerService _service = service;

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetContacts()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/Customers/SampleName
        [HttpGet("{slug}")]
        public async Task<ActionResult<Customer>> GetCustomerByName(string slug)
        {
            var customer = await _service.GetAsync(c => c.Slug == slug);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // GET: api/Customers/WithProjects/SampleName
        [HttpGet("WithProjects/{slug}")]
        public async Task<ActionResult<Customer>> GetCustomerWithProjectsByName(string slug)
        {
            var contact = await _service.GetCustomerWithProjectsAsync(c => c.Slug == slug);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<CustomerEntity>> AddCustomerAsync(CustomerRegistrationForm customerRegForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdCustomer = await _service.AddAsync(customerRegForm);

            return CreatedAtAction(nameof(GetCustomerByName), new { slug = createdCustomer.Slug }, createdCustomer);
        }

        // PUT: api/Customers/SampleName
        [HttpPut("{slug}")]
        public async Task<IActionResult> EditCustomerAsync(Customer updatedCustomer, string slug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldCustomer = await _service.GetAsync(c => c.Slug == slug);

            if (oldCustomer == null)
            {
                return BadRequest();
            }

            var customer = await _service.UpdateAsync(c => c.Slug == oldCustomer.Slug, updatedCustomer);
            return Ok(customer);

        }

        // DELETE: api/Customers/SampleName
        [HttpDelete("{slug}")]
        public async Task<IActionResult> DeleteCustomerEntity(string slug)
        {
            var exists = await _service.ExistsAsync(c => c.Slug == slug);
            if (exists == false)
            {
                return NotFound();
            }

            var response = await _service.RemoveAsync(c => c.Slug == slug);

            return Ok();
        }
    }
}
