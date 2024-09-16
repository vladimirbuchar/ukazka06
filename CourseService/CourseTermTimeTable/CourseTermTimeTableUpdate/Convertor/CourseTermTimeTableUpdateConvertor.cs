using CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Dto;
using Model.Edu.CourseTermDate;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Convertor
{
    public class CourseTermTimeTableUpdateConvertor : ICourseTermTimeTableUpdateConvertor
    {
        public Task<CourseTermDateDbo> ConvertToBussinessEntity(CourseTermTimeTableUpdateDto update, CourseTermDateDbo entity, string culture)
        {
            entity.IsCanceled = update.IsCanceled;
            return Task.FromResult(entity);
        }
    }
}
