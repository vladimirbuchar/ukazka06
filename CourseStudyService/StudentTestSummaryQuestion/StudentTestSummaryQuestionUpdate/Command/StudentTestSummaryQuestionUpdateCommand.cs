using Core.Base.Command.Update;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Convertor;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Dto;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Validator;
using Model.Edu.StudentTestSummaryQuestion;
using Repository.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Command
{
    public class StudentTestSummaryQuestionUpdateCommand : BaseUpdateCommand<StudentTestSummaryQuestionDbo, IStudentTestSummaryQuestionRepository, StudentTestSummaryQuestionUpdateDto, IStudentTestSummaryQuestionUpdateConvertor, IStudentTestSummaryQuestionUpdateValidator>, IStudentTestSummaryQuestionUpdateCommand
    {
        public StudentTestSummaryQuestionUpdateCommand(IStudentTestSummaryQuestionRepository repository, IStudentTestSummaryQuestionUpdateConvertor convertor, IStudentTestSummaryQuestionUpdateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
