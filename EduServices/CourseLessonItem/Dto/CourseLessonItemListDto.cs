using Core.Base.Dto;

namespace EduServices.CourseLessonItem.Dto
{
    public class CourseLessonItemListDto : ListDto
    {
        public string Name { get; set; }
        public string Html { get; set; }
        public int Position { get; set; }
    }
}
