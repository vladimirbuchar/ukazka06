using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.CourseStudy.GetAllStudentTestResult.Dto;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.CourseStudy.GetAllStudentTestResult.Command
{
    public interface IGetAllStudentTestResultCommand : IBaseListCommand<StudentTestSummaryDbo, StudentTestResultListDto, RequestFilter>
    {
    }
}