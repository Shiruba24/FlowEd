using Entity;

namespace API.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CourseDto> Courses { get; set; } = new List<CourseDto>();
    }
}
