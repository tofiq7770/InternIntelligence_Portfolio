using System.ComponentModel.DataAnnotations;
namespace Portfolio.DTOs
{
    public class ContactMessageDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name can't exceed 100 characters.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Subject can't exceed 100 characters.")]
        public string Subject { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Message can't exceed 1000 characters.")]
        public string Message { get; set; }
    }

}
