using Microsoft.AspNetCore.Mvc;
using Portfolio.DTOs;
using Portfolio.Models;
using Portfolio.Service.Interfaces;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IRepository<Skill> _repository;

        public SkillsController(IRepository<Skill> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var skills = await _repository.GetAllAsync();
            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var skill = await _repository.GetByIdAsync(id);
            return skill == null ? NotFound(new { message = "Skill not found" }) : Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SkillDto skillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Validation errors occurred.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var skill = new Skill
            {
                Name = skillDto.Name,
                ProficiencyLevel = skillDto.ProficiencyLevel
            };

            await _repository.AddAsync(skill);
            return CreatedAtAction(nameof(Get), new { id = skill.Id }, skill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SkillDto skillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Validation errors occurred.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var skill = await _repository.GetByIdAsync(id);
            if (skill == null)
                return NotFound(new { message = "Skill not found." });

            skill.Name = skillDto.Name;
            skill.ProficiencyLevel = skillDto.ProficiencyLevel;

            await _repository.UpdateAsync(skill);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _repository.GetByIdAsync(id);
            if (skill == null)
                return NotFound(new { message = "Skill not found." });

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }

}
