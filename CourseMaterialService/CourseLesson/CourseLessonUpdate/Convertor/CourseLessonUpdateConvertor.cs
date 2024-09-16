using CourseMaterialService.CourseLesson.CourseLessonUpdate.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonUpdate.Convertor
{
    public class CourseLessonUpdateConvertor : ICourseLessonUpdateConvertor
    {
        public Task<CourseLessonDbo> ConvertToBussinessEntity(CourseLessonUpdateDto update, CourseLessonDbo entity, string culture)
        {
            entity.CourseLessonTranslations = entity.CourseLessonTranslations.PrepareTranslation(update.Name, update.CultureId);
            return Task.FromResult(entity);
        }
    }
}
