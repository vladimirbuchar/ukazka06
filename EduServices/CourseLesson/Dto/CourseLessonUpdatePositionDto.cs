using Core.Base.Dto;
using System.Collections.Generic;

namespace Services.CourseLesson.Dto
{
    public class CourseLessonUpdatePositionDto : BaseDto
    {
        public List<string> Ids { get; set; }
    }
}
