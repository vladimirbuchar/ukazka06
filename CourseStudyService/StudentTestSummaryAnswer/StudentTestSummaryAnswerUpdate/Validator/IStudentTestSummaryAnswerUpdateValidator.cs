using Core.Base.Validator;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Dto;
using Model.Edu.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Validator
{
    public interface IStudentTestSummaryAnswerUpdateValidator : IBaseUpdateValidator<StudentTestSummaryAnswerDbo, StudentTestSummaryAnswerUpdateDto>
    {
    }
}