using Core.Base.Dto;

namespace Services.CourseLessonItem.Dto
{
    public class CourseLessonItemListDto : ListDto
    {
        public string Name { get; set; }
        public string Html { get; set; }
        public int Position { get; set; }
    }
}
