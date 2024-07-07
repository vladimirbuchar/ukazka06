using Core.Base.Dto;
using System;

namespace Services.CourseStudy.Dto
{
    public class CourseLessonPowerPointFileDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PowerPointFile { get; set; }
    }
}
