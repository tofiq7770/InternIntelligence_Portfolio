namespace Portfolio.Models
{

    public class Achievement : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAchieved { get; set; }
    }
}
