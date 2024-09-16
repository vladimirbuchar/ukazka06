using Core.Base.Command.Create;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Dto;
using Model.Edu.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Command
{
    public interface IStudentTestSummaryAnswerCreateCommand : IBaseCreateCommand<StudentTestSummaryAnswerDbo, StudentTestSummaryAnswerCreateDto>
    {
    }
}