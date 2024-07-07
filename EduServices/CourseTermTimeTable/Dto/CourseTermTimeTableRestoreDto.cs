using System;
using Core.Base.Dto;

namespace Services.CourseTermTimeTable.Dto
{
    public class CourseTermTimeTableRestoreDto : RestoreDto
    {
        public Guid CourseTermId { get; set; }
    }
}
