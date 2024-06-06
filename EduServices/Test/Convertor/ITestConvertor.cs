using Core.Base.Convertor;
using EduServices.Test.Dto;
using Model.Tables.Edu.CourseTest;

namespace EduServices.Test.Convertor
{
    public interface ITestConvertor : IBaseConvertor
    {
        CourseTestDbo ConvertToBussinessEntity(CourseTestCreateDto addCourseTestDto);
        CourseTestDetailDto ConvertToWebModel(CourseTestDbo getCourseTestDetail, string culture);
        CourseTestDbo ConvertToBussinessEntity(CourseTestUpdateDto updateCourseTestDto, CourseTestDbo courseTest = null);
    }
}
