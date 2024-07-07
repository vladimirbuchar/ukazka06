using Core.Base.Dto;
using System;

namespace Services.CourseStudy.Dto
{
    public class GetUserCourseItemDto : BaseDto
    {
        public Guid CourseLessonItem { get; set; }
        public string ItemType { get; set; }
    }
}
