using Core.Base.Convertor;
using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerList.Dto;
using Model.Edu.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerList.Convertor
{
    public interface IStudentTestSummaryAnswerListConvertor : IBaseListConvertor<StudentTestSummaryAnswerDbo, StudentTestSummaryAnswerListDto>
    {
    }
}