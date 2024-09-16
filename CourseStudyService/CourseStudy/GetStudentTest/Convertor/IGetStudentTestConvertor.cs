using Core.Base.Convertor;
using CourseStudyService.CourseStudy.GetStudentTest.Dto;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.CourseStudy.GetStudentTest.Convertor
{
    public interface IGetStudentTestConvertor : IBaseListConvertor<StudentTestSummaryDbo, StudentTestListDto>
    {
    }
}