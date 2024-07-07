using System;
using Core.Base.Dto;

namespace Services.CourseStudy.Dto
{
    public class ResetCourseDto : ListDto
    {
        public Guid StudentTermId { get; set; }
    }
}
