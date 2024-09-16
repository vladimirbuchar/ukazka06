using CourseMaterialService.CourseLesson.CourseLessonDetail.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonDetail.Conveertor
{
    public class CourseLessonDetailConvertor : ICourseLessonDetailConvertor
    {
        public Task<CourseLessonDetailDto> ConvertToWebModel(CourseLessonDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new CourseLessonDetailDto()
                {
                    Name = detail.CourseLessonTranslations.FindTranslation(culture).Name,
                    Id = detail.Id,
                    Type = detail.Type,
                    BankOfQuestion = detail.CourseTest?.CourseTestBankOfQuestions.Select(x => x.BankOfQuestionId).ToList(),
                    DesiredSuccess = detail.CourseTest?.DesiredSuccess,
                    IsRandomGenerateQuestion = detail.CourseTest?.IsRandomGenerateQuestion,
                    MaxRepetition = detail.CourseTest?.MaxRepetition,
                    QuestionCountInTest = detail.CourseTest?.QuestionCountInTest,
                    TimeLimit = detail.CourseTest?.TimeLimit,
                    TestId = detail.CourseTest?.Id
                }
            );
        }
    }
}
