using Core.Base.Dto;
using System.Collections.Generic;

namespace Services.CourseLessonItem.Dto
{
    public class CourseLessonItemUpdatePositionDto : BaseDto
    {
        public List<string> Ids { get; set; }
    }
}
