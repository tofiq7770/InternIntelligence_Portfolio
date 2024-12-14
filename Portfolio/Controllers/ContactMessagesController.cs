using Microsoft.AspNetCore.Mvc;
using Portfolio.DTOs;
using Portfolio.Models;
using Portfolio.Service.Interfaces;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepository<ContactMessage> _repository;

        public ContactController(IRepository<ContactMessage> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] ContactMessageDto contactMessageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Validation errors occurred.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var contactMessage = new ContactMessage
            {
                Name = contactMessageDto.Name,
                Email = contactMessageDto.Email,
                Subject = contactMessageDto.Subject,
                Message = contactMessageDto.Message,
                SubmittedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(contactMessage);
            return Ok(new { message = "Message submitted successfully" });
        }
    }

}
