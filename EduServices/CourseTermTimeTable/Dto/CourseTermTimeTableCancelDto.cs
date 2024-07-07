using Core.Base.Dto;
using System;

namespace Services.CourseTermTimeTable.Dto
{
    public class CourseTermTimeTableCancelDto : DeleteDto
    {
        public Guid CourseTermId { get; set; }
    }
}
