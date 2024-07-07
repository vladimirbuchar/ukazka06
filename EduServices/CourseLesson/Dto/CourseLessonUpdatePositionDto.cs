using System.Collections.Generic;
using Core.Base.Dto;

namespace Services.CourseLesson.Dto
{
    public class CourseLessonUpdatePositionDto : BaseDto
    {
        public List<string> Ids { get; set; }
    }
}
