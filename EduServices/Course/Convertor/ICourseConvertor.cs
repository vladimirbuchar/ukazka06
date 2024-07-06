using System.Collections.Generic;
using Core.Base.Convertor;
using EduServices.Course.Dto;
using EduServices.CourseStudy.Dto;
using Model.Edu.Course;
using Model.Edu.StudentTestSummary;

namespace EduServices.Course.Convertor
{
    public interface ICourseConvertor : IBaseConvertor<CourseDbo, CourseCreateDto, CourseListDto, CourseDetailDto, CourseUpdateDto>
    {
        HashSet<StudentTestListDto> ConvertToWebModel(HashSet<StudentTestSummaryDbo> getStudentTests, string culture);
    }
}
