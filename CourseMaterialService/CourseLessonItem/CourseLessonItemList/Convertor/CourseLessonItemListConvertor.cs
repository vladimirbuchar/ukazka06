using CourseMaterialService.CourseLessonItem.CourseLessonItemList.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemList.Convertor
{
    public class CourseLessonItemListConvertor : ICourseLessonItemListConvertor
    {
        public Task<List<CourseLessonItemListDto>> ConvertToWebModel(List<CourseLessonItemDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new CourseLessonItemListDto()
                {
                    Name = item.CourseLessonItemTranslations.FindTranslation(culture)?.Name,
                    Id = item.Id,
                    Position = item.Position,
                })
                    .ToList()
            );
        }
    }
}
