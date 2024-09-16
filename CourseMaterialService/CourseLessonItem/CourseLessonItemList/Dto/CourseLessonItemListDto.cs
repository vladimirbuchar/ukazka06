using Core.Base.Dto;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemList.Dto
{
    public class CourseLessonItemListDto : ListDto
    {
        public string? Name { get; set; }
        public int Position { get; set; }
    }
}
