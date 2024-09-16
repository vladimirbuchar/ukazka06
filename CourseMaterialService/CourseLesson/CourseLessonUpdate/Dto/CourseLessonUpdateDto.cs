using Core.Base.Dto;
using CourseMaterialService.CourseLesson.CourseTestUpdate.Dto;

namespace CourseMaterialService.CourseLesson.CourseLessonUpdate.Dto
{
    public class CourseLessonUpdateDto : UpdateDto
    {
        public string? Name { get; set; }
        public required CourseTestUpdateDto Test { get; set; }
    }
}
