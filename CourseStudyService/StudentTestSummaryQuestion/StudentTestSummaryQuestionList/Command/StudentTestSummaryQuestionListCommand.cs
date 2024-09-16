using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionList.Convertor;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionList.Dto;
using Model.Edu.StudentTestSummaryQuestion;
using Repository.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionList.Command
{
    public class StudentTestSummaryQuestionListCommand : BaseListCommand<StudentTestSummaryQuestionDbo, IStudentTestSummaryQuestionRepository, StudentTestSummaryQuestionListDto, IStudentTestSummaryQuestionListConvertor, RequestFilter>, IStudentTestSummaryQuestionListCommand
    {
        public StudentTestSummaryQuestionListCommand(IStudentTestSummaryQuestionRepository repository, IStudentTestSummaryQuestionListConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
