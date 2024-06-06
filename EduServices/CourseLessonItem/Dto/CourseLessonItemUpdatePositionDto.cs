using Core.Base.Dto;
using System.Collections.Generic;

namespace EduServices.CourseLessonItem.Dto
{
    public class CourseLessonItemUpdatePositionDto : BaseDto
    {
        public List<string> Ids { get; set; }
    }
}
