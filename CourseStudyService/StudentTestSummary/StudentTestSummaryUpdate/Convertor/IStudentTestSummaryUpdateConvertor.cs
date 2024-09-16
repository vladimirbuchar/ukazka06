using Core.Base.Convertor;
using CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Dto;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Convertor
{
    public interface IStudentTestSummaryUpdateConvertor : IBaseUpdateConvertor<StudentTestSummaryDbo, StudentTestSummaryUpdateDto>
    {
    }
}