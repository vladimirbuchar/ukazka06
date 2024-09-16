using CourseMaterialService.CourseLesson.CourseLessonCreate.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonCreate.Convertor
{
    public class CourseLessonCreateConvertor : ICourseLessonCreateConvertor
    {
        public Task<CourseLessonDbo> ConvertToBussinessEntity(CourseLessonCreateDto create, string culture)
        {
            CourseLessonDbo courseLesson = new() { Type = create.Type, CourseMaterialId = create.MaterialId };
            courseLesson.CourseLessonTranslations = courseLesson.CourseLessonTranslations.PrepareTranslation(create.Name, create.CultureId);
            return Task.FromResult(courseLesson);
        }
    }
}
