using Core.Base.Dto;

namespace Services.CourseLesson.Dto
{
    public class CourseLessonUpdateDto : UpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
