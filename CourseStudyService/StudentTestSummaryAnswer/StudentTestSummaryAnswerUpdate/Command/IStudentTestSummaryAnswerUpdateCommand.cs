using Core.Base.Command.Update;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Dto;
using Model.Edu.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Command
{
    public interface IStudentTestSummaryAnswerUpdateCommand : IBaseUpdateCommand<StudentTestSummaryAnswerDbo, StudentTestSummaryAnswerUpdateDto>
    {
    }
}