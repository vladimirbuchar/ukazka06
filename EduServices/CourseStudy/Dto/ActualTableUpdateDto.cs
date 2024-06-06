using Core.Base.Dto;
using System;

namespace EduServices.CourseStudy.Dto
{
    public class ActualTableUpdateDto : ListDto
    {
        public string Img { get; set; }
        public Guid CourseTermId { get; set; }
    }
}
