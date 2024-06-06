using Core.Base.Dto;
using System;

namespace EduServices.CourseStudy.Dto
{
    public class ResetCourseDto : ListDto
    {
        public Guid StudentTermId { get; set; }
    }
}
