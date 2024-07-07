using System;
using Core.Base.Dto;

namespace Services.CourseStudy.Dto
{
    public class ActualTableUpdateDto : ListDto
    {
        public string Img { get; set; }
        public Guid CourseTermId { get; set; }
    }
}
