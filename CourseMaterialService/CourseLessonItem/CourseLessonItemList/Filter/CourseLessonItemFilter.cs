using Core.Base.Filter;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemList.Filter
{
    public class CourseLessonItemFilter : RequestFilter
    {
        public string? Name { get; set; }
    }
}
