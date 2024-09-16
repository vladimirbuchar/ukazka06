using Core.Base.Dto;
using Core.Constants;
using CourseMaterialService.CourseLesson.CourseTestCreate.Dto;

namespace CourseMaterialService.CourseLesson.CourseLessonCreate.Dto
{
    public class CourseLessonCreateDto : CreateDto
    {
        public string? Name { get; set; }
        public Guid MaterialId { get; set; }
        public string Type { get; set; } = CourseLessonType.COURSE_ITEM;
        public required CourseTestCreateDto Test { get; set; }
    }
}
