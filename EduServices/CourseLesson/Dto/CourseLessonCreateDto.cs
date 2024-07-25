using Core.Base.Dto;
using Core.Constants;
using System;

namespace Services.CourseLesson.Dto
{
    public class CourseLessonCreateDto : CreateDto
    {
        public string Name { get; set; }
        public Guid MaterialId { get; set; }
        public string Type { get; set; } = CourseLessonType.COURSE_ITEM;
    }
}
