using Core.Base.Dto;
using System;

namespace EduServices.CourseTermTimeTable.Dto
{
    public class CourseTermTimeTableGenerateDto : BaseDto
    {
        public Guid CourseTermId { get; set; }
    }
}
