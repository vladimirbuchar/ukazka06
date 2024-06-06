using System;
using Core.Base.Dto;

namespace EduServices.CourseStudy.Dto
{
    public class GetUserCourseItemDto : BaseDto
    {
        public Guid CourseLessonItem { get; set; }
        public string ItemType { get; set; }
    }
}
