using Core.Base.Command.Detail;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionDetail.Dto;
using Model.Edu.StudentTestSummaryQuestion;
using Repository.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionDetail.Command
{
    public class StudentTestSummaryQuestionDetailCommand : BaseDetailCommand<StudentTestSummaryQuestionDbo, IStudentTestSummaryQuestionRepository, StudentTestSummaryQuestionDetailDto>, IStudentTestSummaryQuestionDetailCommand
    {
        public StudentTestSummaryQuestionDetailCommand(IStudentTestSummaryQuestionRepository repository) : base(repository)
        {
        }
    }
}
