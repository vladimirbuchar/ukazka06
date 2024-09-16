using CourseMaterialService.CourseLessonItem.CourseLessonItemDetail.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemDetail.Convertor
{
    public class CourseLessonItemDetailConvertor : ICourseLessonItemDetailConvertor
    {
        public Task<CourseLessonItemDetailDto> ConvertToWebModel(CourseLessonItemDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new CourseLessonItemDetailDto()
                {
                    Name = detail.CourseLessonItemTranslations.FindTranslation(culture)?.Name,
                    Id = detail.Id,
                    Html = detail.CourseLessonItemTranslations.FindTranslation(culture)?.Html,
                    CourseLessonItemTemplateId = detail.CourseLessonItemTemplateId,
                    TemplateIdentificator = detail.CourseLessonItemTemplate.SystemIdentificator,
                    Youtube = detail.Youtube
                }
            );
        }
    }
}
