namespace Portfolio.Models
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public string ProficiencyLevel { get; set; } // e.g., Beginner, Intermediate, Expert
    }
}
