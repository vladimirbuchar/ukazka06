using CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Convertor
{
    public class CourseLessonItemCreateConvertor : ICourseLessonItemCreateConvertor
    {
        public Task<CourseLessonItemDbo> ConvertToBussinessEntity(CourseLessonItemCreateDto create, string culture)
        {
            CourseLessonItemDbo courseLessonItem =
                new()
                {
                    CourseLessonId = create.CourseLessonId,
                    CourseLessonItemTemplateId = create.TemplateId,
                    Youtube = create.Youtube
                };
            courseLessonItem.CourseLessonItemTranslations = courseLessonItem.CourseLessonItemTranslations.PrepareTranslation(
                create.Name,
                create.Html,
                create.CultureId
            );
            return Task.FromResult(courseLessonItem);
        }
    }
}
