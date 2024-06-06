using System.Collections.Generic;
using Core.Base.Convertor;
using EduServices.Course.Dto;
using EduServices.CourseStudy.Dto;
using Model.Tables.Edu.Course;
using Model.Tables.Edu.StudentTestSummary;

namespace EduServices.Course.Convertor
{
    public interface ICourseConvertor : IBaseConvertor<CourseDbo, CourseCreateDto, CourseListInOrganizationDto, CourseDetailDto, CourseUpdateDto>
    {
        HashSet<StudentTestListDto> ConvertToWebModel(HashSet<StudentTestSummaryDbo> getStudentTests, string culture);
    }
}
