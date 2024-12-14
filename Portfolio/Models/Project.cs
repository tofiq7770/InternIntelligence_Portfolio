namespace Portfolio.Models
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string LiveDemoUrl { get; set; }
    }
}




