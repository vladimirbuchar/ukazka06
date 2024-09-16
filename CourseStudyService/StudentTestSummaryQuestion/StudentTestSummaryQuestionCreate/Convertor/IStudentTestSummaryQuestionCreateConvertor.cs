using Core.Base.Convertor;
using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Dto;
using Model.Edu.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Convertor
{
    public interface IStudentTestSummaryQuestionCreateConvertor : IBaseCreateConvertor<StudentTestSummaryQuestionDbo, StudentTestSummaryQuestionCreateDto>
    {
    }
}