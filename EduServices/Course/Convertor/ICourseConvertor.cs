using Core.Base.Convertor;
using Model.Edu.Course;
using Model.Edu.StudentTestSummary;
using Services.Course.Dto;
using Services.CourseStudy.Dto;
using System.Collections.Generic;

namespace Services.Course.Convertor
{
    public interface ICourseConvertor : IBaseConvertor<CourseDbo, CourseCreateDto, CourseListDto, CourseDetailDto, CourseUpdateDto>
    {
        HashSet<StudentTestListDto> ConvertToWebModel(HashSet<StudentTestSummaryDbo> getStudentTests, string culture);
    }
}
