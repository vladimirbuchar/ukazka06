using CourseStudyService.CourseStudy.GetAllStudentTestResult.Dto;
using Model.Edu.CourseLesson;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.CourseStudy.GetAllStudentTestResult.Convertor
{
    public class GetAllStudentTestResultConvertor : IGetAllStudentTestResultConvertor
    {
        public Task<List<StudentTestResultListDto>> ConvertToWebModel(List<StudentTestSummaryDbo> list, List<string> culture)
        {
            return Task.FromResult(list
                .Select(x => new StudentTestResultListDto()
                {
                    FirstName = x.User.Person.FirstName,
                    Id = x.Id,
                    LastName = x.User.Person.LastName,
                    Name = x.CourseTest.CourseLesson.CourseLessonTranslations.FindTranslation(culture).Name,
                    SecondName = x.User.Person.SecondName,
                    UserEmail = x.User.UserEmail,
                    Finish = x.Finish,
                    Score = x.Score,
                    TestCompleted = x.IsSucess
                })
                .ToList());
        }
    }
}
