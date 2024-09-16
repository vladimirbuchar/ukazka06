using Core.Base.Convertor;
using CourseStudyService.StudentTestSummary.StudentTestSummaryDetail.Dto;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.StudentTestSummary.StudentTestSummaryDetail.Convertor
{
    public interface IStudentTestSummaryDetailConvertor : IBaseDetailConvertor<StudentTestSummaryDbo, StudentTestSummaryDetailDto>
    {
    }
}