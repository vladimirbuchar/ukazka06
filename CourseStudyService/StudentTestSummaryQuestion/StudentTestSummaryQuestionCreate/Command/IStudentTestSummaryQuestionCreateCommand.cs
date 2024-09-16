using Core.Base.Command.Create;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Dto;
using Model.Edu.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Command
{
    public interface IStudentTestSummaryQuestionCreateCommand : IBaseCreateCommand<StudentTestSummaryQuestionDbo, StudentTestSummaryQuestionCreateDto>
    {
    }
}