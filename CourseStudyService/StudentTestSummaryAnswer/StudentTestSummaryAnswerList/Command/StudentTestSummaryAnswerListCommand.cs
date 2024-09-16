using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerList.Convertor;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerList.Dto;
using Model.Edu.StudentTestSummaryAnswer;
using Repository.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerList.Command
{
    public class StudentTestSummaryAnswerListCommand : BaseListCommand<StudentTestSummaryAnswerDbo, IStudentTestSummaryAnswerRepository, StudentTestSummaryAnswerListDto, IStudentTestSummaryAnswerListConvertor, RequestFilter>, IStudentTestSummaryAnswerListCommand
    {
        public StudentTestSummaryAnswerListCommand(IStudentTestSummaryAnswerRepository repository, IStudentTestSummaryAnswerListConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
