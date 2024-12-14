using System.ComponentModel.DataAnnotations;

namespace Portfolio.DTOs
{
    public class AchievementDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Achievement title must be between 3 and 100 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Description can't exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date achieved is required.")]
        public DateTime DateAchieved { get; set; }
    }

}
