using Core.Base.Dto;
using System;

namespace EduServices.CourseTermTimeTable.Dto
{
    public class CourseTermTimeTableCancelDto : DeleteDto
    {
        public Guid CourseTermId { get; set; }
    }
}
