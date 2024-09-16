using CourseMaterialService.CourseLesson.CourseTestUpdate.Dto;
using Model.Edu.CourseTest;

namespace CourseMaterialService.CourseLesson.CourseTestUpdate.Convertor
{
    public class CourseTestUpdateConvertor : ICourseTestUpdateConvertor
    {
        public Task<CourseTestDbo> ConvertToBussinessEntity(CourseTestUpdateDto update, CourseTestDbo entity, string culture)
        {
            entity.DesiredSuccess = update.DesiredSuccess;
            entity.IsRandomGenerateQuestion = update.IsRandomGenerateQuestion;
            entity.QuestionCountInTest = update.QuestionCountInTest;
            entity.TimeLimit = update.TimeLimit;
            entity.MaxRepetition = update.MaxRepetition;
            return Task.FromResult(entity);
        }
    }
}
