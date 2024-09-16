using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionList.Dto;
using Model.Edu.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionList.Command
{
    public interface IStudentTestSummaryQuestionListCommand : IBaseListCommand<StudentTestSummaryQuestionDbo, StudentTestSummaryQuestionListDto, RequestFilter>
    {
    }
}