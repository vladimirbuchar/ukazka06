using System;
using Core.Base.Dto;

namespace Services.CourseTermTimeTable.Dto
{
    public class CourseTermTimeTableGenerateDto : BaseDto
    {
        public Guid CourseTermId { get; set; }
    }
}
