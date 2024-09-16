using Core.Base.Dto;

namespace CourseStudyService.CourseStudy.GetUserCourseItem.Dto
{
    public class GetUserCourseItemDto : DetailDto
    {
        public Guid CourseLessonItem { get; set; }
        public string? ItemType { get; set; }
    }
}
