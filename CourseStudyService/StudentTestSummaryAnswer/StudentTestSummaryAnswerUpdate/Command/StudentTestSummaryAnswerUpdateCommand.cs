using Core.Base.Command.Update;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Convertor;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Dto;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Validator;
using Model.Edu.StudentTestSummaryAnswer;
using Repository.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Command
{
    public class StudentTestSummaryAnswerUpdateCommand : BaseUpdateCommand<StudentTestSummaryAnswerDbo, IStudentTestSummaryAnswerRepository, StudentTestSummaryAnswerUpdateDto, IStudentTestSummaryAnswerUpdateConvertor, IStudentTestSummaryAnswerUpdateValidator>, IStudentTestSummaryAnswerUpdateCommand
    {
        public StudentTestSummaryAnswerUpdateCommand(IStudentTestSummaryAnswerRepository repository, IStudentTestSummaryAnswerUpdateConvertor convertor, IStudentTestSummaryAnswerUpdateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
