using Core.Base.Convertor;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Dto;
using Model.Edu.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Convertor
{
    public interface IStudentTestSummaryAnswerCreateConvertor : IBaseCreateConvertor<StudentTestSummaryAnswerDbo, StudentTestSummaryAnswerCreateDto>
    {
    }
}