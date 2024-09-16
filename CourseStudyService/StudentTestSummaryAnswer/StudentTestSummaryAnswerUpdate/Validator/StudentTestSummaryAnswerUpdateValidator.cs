using Core.Base.Validator;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Dto;
using Model.Edu.StudentTestSummaryAnswer;
using Repository.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Validator
{
    public class StudentTestSummaryAnswerUpdateValidator : BaseUpdateValidator<StudentTestSummaryAnswerDbo, IStudentTestSummaryAnswerRepository, StudentTestSummaryAnswerUpdateDto>, IStudentTestSummaryAnswerUpdateValidator
    {
        public StudentTestSummaryAnswerUpdateValidator(IStudentTestSummaryAnswerRepository repository) : base(repository)
        {
        }
    }
}
