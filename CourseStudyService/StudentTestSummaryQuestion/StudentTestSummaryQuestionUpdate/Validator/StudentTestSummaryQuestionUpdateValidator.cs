using Core.Base.Validator;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Dto;
using Model.Edu.StudentTestSummaryQuestion;
using Repository.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Validator
{
    public class StudentTestSummaryQuestionUpdateValidator : BaseUpdateValidator<StudentTestSummaryQuestionDbo, IStudentTestSummaryQuestionRepository, StudentTestSummaryQuestionUpdateDto>, IStudentTestSummaryQuestionUpdateValidator
    {
        public StudentTestSummaryQuestionUpdateValidator(IStudentTestSummaryQuestionRepository repository) : base(repository)
        {
        }
    }
}
