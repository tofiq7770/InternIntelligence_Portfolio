using System.ComponentModel.DataAnnotations;
namespace Portfolio.DTOs
{
    public class SkillDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Skill name must be between 2 and 50 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Proficiency level can't exceed 50 characters.")]
        public string ProficiencyLevel { get; set; }
    }

}
