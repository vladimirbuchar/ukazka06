using Core.Base.Validator;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Dto;
using Model.Edu.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Validator
{
    public interface IStudentTestSummaryQuestionUpdateValidator : IBaseUpdateValidator<StudentTestSummaryQuestionDbo, StudentTestSummaryQuestionUpdateDto>
    {
    }
}