using Business_Logic.Dtos;
using Business_Logic.Interfaces;
using Business_Logic.Models;
using BusinessX_Data.Dtos;
using BusinessX_Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BusinessX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService service) : ControllerBase
    {
        private readonly IProjectService _service = service;

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectByName(string name)
        {
            var project = await _service.GetAsync(c => c.Name == name);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // GET: api/Projects/recent
        [HttpGet("recent")]
        public async Task<ActionResult<IEnumerable<RecentProjectsDto>>> GetRecentProjects()
        {
            var projects = await _service.GetRecentAsync();

            if (projects == null)
            {
                return NotFound();
            }

            return Ok(projects);
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<ProjectEntity>> AddProjectAsync(ProjectRegistrationForm ProjectRegForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdProject = await _service.AddAsync(ProjectRegForm);

            return CreatedAtAction(nameof(GetProjectByName), new { id = createdProject.Id }, createdProject);
        }

        // PUT: api/Projects/5
        [HttpPut("{name}")]
        public async Task<IActionResult> EditProjectAsync(Project updatedProject, string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldProject = await _service.GetAsync(c => c.Name == name);

            if (oldProject == null)
            {
                return BadRequest();
            }

            var Project = await _service.UpdateAsync(c => c.Id == oldProject.Id, updatedProject);
            return Ok(Project);

        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectEntity(int id)
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
