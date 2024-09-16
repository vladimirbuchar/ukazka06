using Core.Base.Convertor;
using CourseStudyService.CourseStudy.GetAllStudentTestResult.Dto;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.CourseStudy.GetAllStudentTestResult.Convertor
{
    public interface IGetAllStudentTestResultConvertor : IBaseListConvertor<StudentTestSummaryDbo, StudentTestResultListDto>
    {
    }
}