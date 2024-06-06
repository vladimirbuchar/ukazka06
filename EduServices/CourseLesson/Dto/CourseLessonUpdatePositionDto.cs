using Core.Base.Dto;
using System.Collections.Generic;

namespace EduServices.CourseLesson.Dto
{
    public class CourseLessonUpdatePositionDto : BaseDto
    {
        public List<string> Ids { get; set; }
    }
}
