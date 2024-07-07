using Core.Base.Dto;
using System;

namespace Services.CourseStudy.Dto
{
    public class SlideIdListDto : ListDto
    {
        public Guid ParentId { get; set; }
        public string Name { get; set; }
    }
}
