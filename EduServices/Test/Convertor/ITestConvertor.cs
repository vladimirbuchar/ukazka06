using Core.Base.Convertor;
using Model.Edu.CourseTest;
using Services.Test.Dto;

namespace Services.Test.Convertor
{
    public interface ITestConvertor : IBaseConvertor
    {
        CourseTestDbo ConvertToBussinessEntity(CourseTestCreateDto addCourseTestDto);
        CourseTestDetailDto ConvertToWebModel(CourseTestDbo getCourseTestDetail, string culture);
        CourseTestDbo ConvertToBussinessEntity(CourseTestUpdateDto updateCourseTestDto, CourseTestDbo courseTest = null);
    }
}
