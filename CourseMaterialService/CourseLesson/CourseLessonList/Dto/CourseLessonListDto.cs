using Core.Base.Dto;

namespace CourseMaterialService.CourseLesson.CourseLessonList.Dto
{
    public class CourseLessonListDto : ListDto
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int Position { get; set; }
    }
}
