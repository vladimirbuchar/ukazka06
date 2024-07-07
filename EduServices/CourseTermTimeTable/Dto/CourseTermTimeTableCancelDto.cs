using System;
using Core.Base.Dto;

namespace Services.CourseTermTimeTable.Dto
{
    public class CourseTermTimeTableCancelDto : DeleteDto
    {
        public Guid CourseTermId { get; set; }
    }
}
