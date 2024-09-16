using CourseStudyService.CourseStudy.GetStudentTest.Dto;
using Model.Edu.CourseLesson;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.CourseStudy.GetStudentTest.Convertor
{
    public class GetStudentTestConvertor : IGetStudentTestConvertor
    {
        public Task<List<StudentTestListDto>> ConvertToWebModel(List<StudentTestSummaryDbo> list, List<string> culture)
        {
            return Task.FromResult(list
                .Select(x => new StudentTestListDto()
                {
                    Finish = x.Finish.Value,
                    Id = x.Id,
                    Name = x.CourseTest.CourseLesson.CourseLessonTranslations.FindTranslation(culture).Name,
                    Score = x.Score,
                    TestCompleted = x.IsSucess,
                    TestId = x.CourseTestId,
                    CourseMaterialId = x.CourseTest.CourseLesson.CourseMaterialId,
                    CourseId = x.CourseId
                })
                .ToList());
        }
    }
}
