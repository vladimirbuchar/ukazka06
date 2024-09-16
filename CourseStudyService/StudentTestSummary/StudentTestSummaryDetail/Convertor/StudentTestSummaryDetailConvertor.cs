using CourseStudyService.StudentTestSummary.StudentTestSummaryDetail.Dto;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.StudentTestSummary.StudentTestSummaryDetail.Convertor
{
    public class StudentTestSummaryDetailConvertor : IStudentTestSummaryDetailConvertor
    {
        public Task<StudentTestSummaryDetailDto> ConvertToWebModel(StudentTestSummaryDbo detail, List<string> culture)
        {
            return Task.FromResult(new StudentTestSummaryDetailDto()
            {
                DesiredSuccess = detail.CourseTest.DesiredSuccess,
                Id = detail.Id
            });
        }
    }
}
