using System;
using Core.Base.Dto;

namespace EduServices.CourseStudy.Dto
{
    public class SlideIdListDto : ListDto
    {
        public Guid ParentId { get; set; }
        public string Name { get; set; }
    }
}
