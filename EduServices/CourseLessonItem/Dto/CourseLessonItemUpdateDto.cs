using Core.Base.Dto;
using System;

namespace Services.CourseLessonItem.Dto
{
    public class CourseLessonItemUpdateDto : UpdateDto
    {
        public string Html { get; set; }
        public string Name { get; set; }
        public Guid TemplateId { get; set; }
        public string Youtube { get; set; }
    }
}
