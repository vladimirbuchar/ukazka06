using System;
using Core.Base.Dto;

namespace Services.CourseLessonItem.Dto
{
    public class CourseLessonItemCreateDto : CreateDto
    {
        public Guid CourseLessonId { get; set; }
        public string Html { get; set; }
        public string Name { get; set; }
        public Guid TemplateId { get; set; }
        public string Youtube { get; set; }
    }
}
