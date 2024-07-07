using Core.Base.Dto;
using System;

namespace Services.CourseTermTimeTable.Dto
{
    public class CourseTermTimeTableGenerateDto : BaseDto
    {
        public Guid CourseTermId { get; set; }
    }
}
