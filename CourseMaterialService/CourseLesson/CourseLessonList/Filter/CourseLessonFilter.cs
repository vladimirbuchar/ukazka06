using Core.Base.Filter;

namespace CourseMaterialService.CourseLesson.CourseLessonList.Filter
{
    public class CourseLessonFilter : RequestFilter
    {
        public string? Name { get; set; }
    }
}
