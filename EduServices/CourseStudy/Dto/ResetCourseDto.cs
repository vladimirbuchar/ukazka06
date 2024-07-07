using Core.Base.Dto;
using System;

namespace Services.CourseStudy.Dto
{
    public class ResetCourseDto : ListDto
    {
        public Guid StudentTermId { get; set; }
    }
}
