using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerList.Dto;
using Model.Edu.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerList.Command
{
    public interface IStudentTestSummaryAnswerListCommand : IBaseListCommand<StudentTestSummaryAnswerDbo, StudentTestSummaryAnswerListDto, RequestFilter>
    {
    }
}