using Core.Base.Command.Update;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Dto;
using Model.Edu.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Command
{
    public interface IStudentTestSummaryQuestionUpdateCommand : IBaseUpdateCommand<StudentTestSummaryQuestionDbo, StudentTestSummaryQuestionUpdateDto>
    {
    }
}