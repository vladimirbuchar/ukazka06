using EduServices.Test.Dto;
using Model.Edu.CourseLesson;
using Model.Edu.CourseTest;
using System.Linq;

namespace EduServices.Test.Convertor
{
    public class TestConvertor() : ITestConvertor
    {
        public CourseTestDbo ConvertToBussinessEntity(CourseTestCreateDto addCourseTestDto)
        {
            return new CourseTestDbo()
            {
                DesiredSuccess = addCourseTestDto.DesiredSuccess,
                IsRandomGenerateQuestion = addCourseTestDto.IsRandomGenerateQuestion,
                QuestionCountInTest = addCourseTestDto.QuestionCountInTest,
                TimeLimit = addCourseTestDto.TimeLimit,
                MaxRepetition = addCourseTestDto.MaxRepetition
            };
        }

        public CourseTestDbo ConvertToBussinessEntity(CourseTestUpdateDto updateCourseTestDto, CourseTestDbo courseTest = null)
        {
            courseTest.DesiredSuccess = updateCourseTestDto.DesiredSuccess;
            courseTest.IsRandomGenerateQuestion = updateCourseTestDto.IsRandomGenerateQuestion;
            courseTest.QuestionCountInTest = updateCourseTestDto.QuestionCountInTest;
            courseTest.TimeLimit = updateCourseTestDto.TimeLimit;
            courseTest.MaxRepetition = updateCourseTestDto.MaxRepetition;
            return courseTest;
        }

        public CourseTestDetailDto ConvertToWebModel(CourseTestDbo getCourseTestDetail, string culture)
        {
            return new CourseTestDetailDto()
            {
                DesiredSuccess = getCourseTestDetail.DesiredSuccess,
                Id = getCourseTestDetail.Id,
                IsRandomGenerateQuestion = getCourseTestDetail.IsRandomGenerateQuestion,
                Name = getCourseTestDetail.CourseLesson.CourseLessonTranslations.FindTranslation(culture).Name,
                QuestionCountInTest = getCourseTestDetail.QuestionCountInTest,
                TimeLimit = getCourseTestDetail.TimeLimit,
                BankOfQuestion = getCourseTestDetail.CourseTestBankOfQuestions.Select(x => x.BankOfQuestionId).ToHashSet(),
                MaxRepetition = getCourseTestDetail.MaxRepetition
            };
        }
    }
}
