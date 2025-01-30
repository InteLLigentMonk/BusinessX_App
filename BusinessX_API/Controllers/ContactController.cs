using Microsoft.AspNetCore.Mvc;
using BusinessX_Data.Entities;
using Business_Logic.Models;
using Business_Logic.Dtos;
using Business_Logic.Interfaces;

namespace BusinessX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        // GET: api/Contact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/Contact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            var contact = await _service.GetAsync(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // GET: api/Contact/WithCustomers/5
        [HttpGet("WithCustomers/{id}")]
        public async Task<ActionResult<Contact>> GetContactWithCustomersById(int id)
        {
            var contact = await _service.GetContactWithCustomersAsync(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<ActionResult<ContactEntity>> AddContactAsync(ContactRegistrationForm contactRegForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdContact = await _service.AddAsync(contactRegForm);

            return CreatedAtAction(nameof(GetContactById), new { id = createdContact.Id }, createdContact);
        }

        // PUT: api/Contact/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditContactAsync(Contact updatedContact, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldContact = await _service.GetAsync(c => c.Id == id);

            if (oldContact == null)
            {
                return BadRequest();
            }

            var contact = await _service.UpdateAsync(c => c.Id == oldContact.Id, updatedContact);
            return Ok(contact);

        }

        // DELETE: api/Contact/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactEntity(int id)
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
