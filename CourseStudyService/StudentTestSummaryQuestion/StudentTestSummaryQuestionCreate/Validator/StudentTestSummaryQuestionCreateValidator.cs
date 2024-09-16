using Core.Base.Validator;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Dto;
using Model.Edu.StudentTestSummaryQuestion;
using Repository.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Validator
{
    public class StudentTestSummaryQuestionCreateValidator : BaseCreateValidator<StudentTestSummaryQuestionDbo, IStudentTestSummaryQuestionRepository, StudentTestSummaryQuestionCreateDto>, IStudentTestSummaryQuestionCreateValidator
    {
        public StudentTestSummaryQuestionCreateValidator(IStudentTestSummaryQuestionRepository repository) : base(repository)
        {
        }
    }
}
