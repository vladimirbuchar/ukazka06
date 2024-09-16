using Core.Base.Convertor;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Dto;
using Model.Edu.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Convertor
{
    public interface IStudentTestSummaryAnswerUpdateConvertor : IBaseUpdateConvertor<StudentTestSummaryAnswerDbo, StudentTestSummaryAnswerUpdateDto>
    {
    }
}