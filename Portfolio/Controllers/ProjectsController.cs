using Microsoft.AspNetCore.Mvc;
using Portfolio.DTOs;
using Portfolio.Models;
using Portfolio.Service.Interfaces;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IRepository<Project> _repository;

        public ProjectsController(IRepository<Project> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _repository.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _repository.GetByIdAsync(id);
            return project == null ? NotFound(new { message = "Project not found" }) : Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Validation errors occurred.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var project = new Project
            {
                Name = projectDto.Name,
                Description = projectDto.Description,
                ImageUrl = projectDto.ImageUrl,
                GitHubUrl = projectDto.GitHubUrl,
                LiveDemoUrl = projectDto.LiveDemoUrl
            };

            await _repository.AddAsync(project);
            return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Validation errors occurred.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var project = await _repository.GetByIdAsync(id);
            if (project == null)
                return NotFound(new { message = "Project not found." });

            project.Name = projectDto.Name;
            project.Description = projectDto.Description;
            project.ImageUrl = projectDto.ImageUrl;
            project.GitHubUrl = projectDto.GitHubUrl;
            project.LiveDemoUrl = projectDto.LiveDemoUrl;

            await _repository.UpdateAsync(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null)
                return NotFound(new { message = "Project not found." });

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }


}
