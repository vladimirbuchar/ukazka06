using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.CourseStudy.GetStudentTest.Dto;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.CourseStudy.GetStudentTest.Command
{
    public interface IGetStudentTestCommand : IBaseListCommand<StudentTestSummaryDbo, StudentTestListDto, RequestFilter>
    {
    }
}