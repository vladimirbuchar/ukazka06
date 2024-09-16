using Core.Base.Validator;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Dto;
using Model.Edu.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Validator
{
    public interface IStudentTestSummaryAnswerCreateValidator : IBaseCreateValidator<StudentTestSummaryAnswerDbo, StudentTestSummaryAnswerCreateDto>
    {
    }
}