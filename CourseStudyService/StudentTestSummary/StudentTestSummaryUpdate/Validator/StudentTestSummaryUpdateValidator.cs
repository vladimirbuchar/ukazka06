using Core.Base.Validator;
using CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Dto;
using Model.Edu.StudentTestSummary;
using Repository.StudentTestSummary;

namespace CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Validator
{
    public class StudentTestSummaryUpdateValidator : BaseUpdateValidator<StudentTestSummaryDbo, IStudentTestSummaryRepository, StudentTestSummaryUpdateDto>, IStudentTestSummaryUpdateValidator
    {
        public StudentTestSummaryUpdateValidator(IStudentTestSummaryRepository repository) : base(repository)
        {
        }
    }
}
