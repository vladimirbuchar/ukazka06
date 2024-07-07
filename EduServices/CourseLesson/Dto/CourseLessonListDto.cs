using Core.Base.Dto;

namespace Services.CourseLesson.Dto
{
    public class CourseLessonListDto : ListDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Position { get; set; }
    }
}
