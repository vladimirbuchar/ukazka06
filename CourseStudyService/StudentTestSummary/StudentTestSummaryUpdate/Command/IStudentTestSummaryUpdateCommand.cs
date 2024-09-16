using Core.Base.Command.Update;
using CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Dto;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Command
{
    public interface IStudentTestSummaryUpdateCommand : IBaseUpdateCommand<StudentTestSummaryDbo, StudentTestSummaryUpdateDto>
    {
    }
}