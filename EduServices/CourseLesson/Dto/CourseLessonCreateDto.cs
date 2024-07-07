using System;
using Core.Base.Dto;
using Core.Constants;

namespace Services.CourseLesson.Dto
{
    public class CourseLessonCreateDto : CreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid MaterialId { get; set; }
        public string Type { get; set; } = CourseLessonType.COURSE_ITEM;
    }
}
