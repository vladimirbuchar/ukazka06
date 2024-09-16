using Core.Base.Command.Create;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Convertor;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Dto;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Validator;
using Model.Edu.StudentTestSummaryQuestion;
using Repository.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Command
{
    public class StudentTestSummaryQuestionCreateCommand : BaseCreateCommand<StudentTestSummaryQuestionDbo, IStudentTestSummaryQuestionRepository, StudentTestSummaryQuestionCreateDto, IStudentTestSummaryQuestionCreateConvertor, IStudentTestSummaryQuestionCreateValidator>, IStudentTestSummaryQuestionCreateCommand
    {
        public StudentTestSummaryQuestionCreateCommand(IStudentTestSummaryQuestionRepository repository, IStudentTestSummaryQuestionCreateConvertor convertor, IStudentTestSummaryQuestionCreateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
