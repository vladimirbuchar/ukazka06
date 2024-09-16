using CourseMaterialService.CourseLesson.CourseLessonList.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonList.Convertor
{
    public class CourseLessonListConvertor : ICourseLessonListConvertor
    {
        public Task<List<CourseLessonListDto>> ConvertToWebModel(List<CourseLessonDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new CourseLessonListDto()
                {
                    Name = item.CourseLessonTranslations.FindTranslation(culture).Name,
                    Id = item.Id,
                    Type = item.Type,
                    Position = item.Position,
                })
                    .ToList()
            );
        }
    }
}
