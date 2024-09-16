using Core.Base.Command.Detail;
using CourseStudyService.StudentTestSummary.StudentTestSummaryDetail.Dto;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.StudentTestSummary.StudentTestSummaryDetail.Command
{
    public interface IStudentTestSummaryDetailCommand : IBaseDetailCommand<StudentTestSummaryDbo, StudentTestSummaryDetailDto>
    {
    }
}