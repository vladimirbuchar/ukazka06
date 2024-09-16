using Core.Constants;
using CourseStudyService.CourseStudy.CourseMenu.Dto;
using CourseStudyService.CourseStudy.Dto;
using Model.Edu.CourseLesson;
using Model.Edu.CourseLessonItem;

namespace CourseStudyService.CourseStudy.CourseMenu.Convertor
{
    public class CourseMenuConvertor : ICourseMenuConvertor
    {
        public Task<List<CourseMenuItemDto>> ConvertToWebModel(List<CourseLessonDbo> list, List<string> culture)
        {
            return Task.FromResult(list
                .Select(x => new CourseMenuItemDto()
                {
                    Id = x.Id,
                    Name = x.CourseLessonTranslations.FindTranslation(culture).Name,
                    Items = x.CourseItem
                        .Select(y => new CourseMenuSubItemDto()
                        {
                            Id = y.Id,
                            Name = y.CourseLessonItemTranslations.FindTranslation(culture).Name,
                            Type = CourseLessonType.COURSE_ITEM
                        })
                        .ToList(),
                    Type = x.Type ?? CourseLessonType.COURSE_ITEM
                })
                .Where(x =>
                    x.Type == CourseLessonType.COURSE_TEST
                    || x.Type == CourseLessonType.COURSE_ITEM_POWER_POINT
                    || (x.Type == CourseLessonType.SUB_ITEM && x.Items.Count > 0)
                )
                .ToList());

        }
    }
}
