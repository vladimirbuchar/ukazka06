using Core.Base.Dto;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemDetail.Dto
{
    public class CourseLessonItemDetailDto : DetailDto
    {
        public string Html { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Guid CourseLessonItemTemplateId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string TemplateIdentificator { get; set; } = string.Empty;
        public string OriginalFileName { get; set; } = string.Empty;
        public Guid FileId { get; set; }
        public string Youtube { get; set; } = string.Empty;
    }
}
