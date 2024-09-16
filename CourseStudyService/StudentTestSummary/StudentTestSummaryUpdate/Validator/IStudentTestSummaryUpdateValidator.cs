using Core.Base.Validator;
using CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Dto;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Validator
{
    public interface IStudentTestSummaryUpdateValidator : IBaseUpdateValidator<StudentTestSummaryDbo, StudentTestSummaryUpdateDto>
    {
    }
}