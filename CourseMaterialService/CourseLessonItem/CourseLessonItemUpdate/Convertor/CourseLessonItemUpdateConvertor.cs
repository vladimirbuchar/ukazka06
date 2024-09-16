using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Convertor
{
    public class CourseLessonItemUpdateConvertor : ICourseLessonItemUpdateConvertor
    {
        public Task<CourseLessonItemDbo> ConvertToBussinessEntity(CourseLessonItemUpdateDto update, CourseLessonItemDbo entity, string culture)
        {
            entity.Youtube = update.Youtube;
            entity.CourseLessonItemTemplateId = update.TemplateId;
            entity.CourseLessonItemTranslations = entity.CourseLessonItemTranslations.PrepareTranslation(update.Name, update.Html, update.CultureId);
            return Task.FromResult(entity);
        }
    }
}
