using Core.Base.Command.Create;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Convertor;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Dto;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Validator;
using Model.Edu.StudentTestSummaryAnswer;
using Repository.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Command
{
    public class StudentTestSummaryAnswerCreateCommand : BaseCreateCommand<StudentTestSummaryAnswerDbo, IStudentTestSummaryAnswerRepository, StudentTestSummaryAnswerCreateDto, IStudentTestSummaryAnswerCreateConvertor, IStudentTestSummaryAnswerCreateValidator>, IStudentTestSummaryAnswerCreateCommand
    {
        public StudentTestSummaryAnswerCreateCommand(IStudentTestSummaryAnswerRepository repository, IStudentTestSummaryAnswerCreateConvertor convertor, IStudentTestSummaryAnswerCreateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
