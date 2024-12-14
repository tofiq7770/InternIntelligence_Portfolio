using Microsoft.AspNetCore.Mvc;
using Portfolio.DTOs;
using Portfolio.Models;
using Portfolio.Service.Interfaces;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {
        private readonly IRepository<Achievement> _repository;

        public AchievementsController(IRepository<Achievement> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var achievements = await _repository.GetAllAsync();
            return Ok(achievements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var achievement = await _repository.GetByIdAsync(id);
            return achievement == null ? NotFound(new { message = "Achievement not found" }) : Ok(achievement);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AchievementDto achievementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Validation errors occurred.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var achievement = new Achievement
            {
                Title = achievementDto.Title,
                Description = achievementDto.Description,
                DateAchieved = achievementDto.DateAchieved
            };

            await _repository.AddAsync(achievement);
            return CreatedAtAction(nameof(Get), new { id = achievement.Id }, achievement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AchievementDto achievementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Validation errors occurred.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var achievement = await _repository.GetByIdAsync(id);
            if (achievement == null)
                return NotFound(new { message = "Achievement not found." });

            achievement.Title = achievementDto.Title;
            achievement.Description = achievementDto.Description;
            achievement.DateAchieved = achievementDto.DateAchieved;

            await _repository.UpdateAsync(achievement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var achievement = await _repository.GetByIdAsync(id);
            if (achievement == null)
                return NotFound(new { message = "Achievement not found." });

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }

}
