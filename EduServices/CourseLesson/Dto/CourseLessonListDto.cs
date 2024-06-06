using Core.Base.Dto;

namespace EduServices.CourseLesson.Dto
{
    public class CourseLessonListDto : ListDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Position { get; set; }
    }
}
