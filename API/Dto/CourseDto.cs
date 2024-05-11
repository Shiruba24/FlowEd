using Entity;

namespace API.Dto
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Instructor { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Image { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Students { get; set; }
        public string Language { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;

        public ICollection<RequirementDto> Requirements { get; set; } = new List<RequirementDto>();
        public ICollection<LearningDto> Learnings { get; set; } = new List<LearningDto>();

        public string Category { get; set; } = string.Empty;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
