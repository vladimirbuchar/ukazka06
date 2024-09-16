using CourseMaterialService.CourseLesson.CourseTestCreate.Dto;
using Model.Edu.CourseTest;

namespace CourseMaterialService.CourseLesson.CourseTestCreate.Convertor
{
    public class CourseTestCreateConvertor : ICourseTestCreateConvertor
    {
        public Task<CourseTestDbo> ConvertToBussinessEntity(CourseTestCreateDto create, string culture)
        {
            return Task.FromResult(
                new CourseTestDbo()
                {
                    DesiredSuccess = create.DesiredSuccess,
                    IsRandomGenerateQuestion = create.IsRandomGenerateQuestion,
                    QuestionCountInTest = create.QuestionCountInTest,
                    TimeLimit = create.TimeLimit,
                    MaxRepetition = create.MaxRepetition,
                    CourseLessonId = create.CourseLessonId
                }
            );
        }
    }
}
