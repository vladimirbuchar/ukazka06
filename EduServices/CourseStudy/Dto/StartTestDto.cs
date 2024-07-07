using Core.Base.Dto;
using System;

namespace Services.CourseStudy.Dto
{
    public class StartTestDto : ListDto
    {
        public Guid CourseLessonId { get; set; }
        public Guid CourseId { get; set; }
    }
}
