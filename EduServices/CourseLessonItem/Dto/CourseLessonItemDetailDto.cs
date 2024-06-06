using System;
using Core.Base.Dto;

namespace EduServices.CourseLessonItem.Dto
{
    public class CourseLessonItemDetailDto : DetailDto
    {
        public string Html { get; set; }
        public string Name { get; set; }
        public Guid CourseLessonItemTemplateId { get; set; }
        public string TemplateIdentificator { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public Guid FileId { get; set; }
        public string Youtube { get; set; }
    }
}
