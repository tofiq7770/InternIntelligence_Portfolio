using System.ComponentModel.DataAnnotations;

namespace Portfolio.DTOs
{
    public class ProjectDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Project name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Description can't exceed 500 characters.")]
        public string Description { get; set; }

        [Url(ErrorMessage = "Please provide a valid URL for the image.")]
        public string ImageUrl { get; set; }

        [Url(ErrorMessage = "Please provide a valid GitHub URL.")]
        public string GitHubUrl { get; set; }

        [Url(ErrorMessage = "Please provide a valid Live Demo URL.")]
        public string LiveDemoUrl { get; set; }
    }

}
