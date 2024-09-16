using Core.Base.Command.Detail;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionDetail.Dto;
using Model.Edu.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionDetail.Command
{
    public interface IStudentTestSummaryQuestionDetailCommand : IBaseDetailCommand<StudentTestSummaryQuestionDbo, StudentTestSummaryQuestionDetailDto>
    {
    }
}