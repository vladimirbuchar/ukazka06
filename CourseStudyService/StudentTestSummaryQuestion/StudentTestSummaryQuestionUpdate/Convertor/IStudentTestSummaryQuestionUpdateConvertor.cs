using Core.Base.Convertor;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Dto;
using Model.Edu.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Convertor
{
    public interface IStudentTestSummaryQuestionUpdateConvertor : IBaseUpdateConvertor<StudentTestSummaryQuestionDbo, StudentTestSummaryQuestionUpdateDto>
    {
    }
}