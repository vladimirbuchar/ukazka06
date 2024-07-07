using System;
using Core.Base.Dto;

namespace Services.CourseStudy.Dto
{
    public class GetUserCourseItemDto : BaseDto
    {
        public Guid CourseLessonItem { get; set; }
        public string ItemType { get; set; }
    }
}
