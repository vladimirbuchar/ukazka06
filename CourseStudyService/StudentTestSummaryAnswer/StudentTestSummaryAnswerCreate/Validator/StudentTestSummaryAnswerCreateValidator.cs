using Core.Base.Validator;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Dto;
using Model.Edu.StudentTestSummaryAnswer;
using Repository.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Validator
{
    public class StudentTestSummaryAnswerCreateValidator : BaseCreateValidator<StudentTestSummaryAnswerDbo, IStudentTestSummaryAnswerRepository, StudentTestSummaryAnswerCreateDto>, IStudentTestSummaryAnswerCreateValidator
    {
        public StudentTestSummaryAnswerCreateValidator(IStudentTestSummaryAnswerRepository repository) : base(repository)
        {
        }
    }
}
