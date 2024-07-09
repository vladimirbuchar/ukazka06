using System.Collections.Generic;
using Core.Base.Convertor;
using Model.Edu.Course;
using Model.Edu.StudentTestSummary;
using Services.Course.Dto;
using Services.CourseStudy.Dto;

namespace Services.Course.Convertor
{
    public interface ICourseConvertor : IBaseConvertor<CourseDbo, CourseCreateDto, CourseListDto, CourseDetailDto, CourseUpdateDto>
    {
        List<StudentTestListDto> ConvertToWebModel(List<StudentTestSummaryDbo> getStudentTests, string culture);
    }
}
