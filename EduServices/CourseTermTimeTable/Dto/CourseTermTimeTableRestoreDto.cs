using Core.Base.Dto;
using System;

namespace EduServices.CourseTermTimeTable.Dto
{
    public class CourseTermTimeTableRestoreDto : RestoreDto
    {
        public Guid CourseTermId { get; set; }
    }
}
