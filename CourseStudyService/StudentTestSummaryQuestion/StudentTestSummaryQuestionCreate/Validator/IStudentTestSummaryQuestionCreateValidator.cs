using Core.Base.Validator;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Dto;
using Model.Edu.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Validator
{
    public interface IStudentTestSummaryQuestionCreateValidator : IBaseCreateValidator<StudentTestSummaryQuestionDbo, StudentTestSummaryQuestionCreateDto>
    {
    }
}