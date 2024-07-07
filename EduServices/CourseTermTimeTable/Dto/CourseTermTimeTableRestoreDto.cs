using Core.Base.Dto;
using System;

namespace Services.CourseTermTimeTable.Dto
{
    public class CourseTermTimeTableRestoreDto : RestoreDto
    {
        public Guid CourseTermId { get; set; }
    }
}
