using System.Collections.Generic;
using Core.Base.Convertor;
using Model.Edu.Course;
using Model.Edu.StudentTestSummary;
using Services.Course.Dto;
using Services.CourseStudy.Dto;

namespace Services.CourseStudy.Convertor
{
    public interface ICourseStudyConvertor : IBaseConvertor<CourseDbo, CourseCreateDto, CourseListDto, CourseDetailDto, CourseUpdateDto>
    {
        HashSet<StudentTestListDto> ConvertToWebModel(HashSet<StudentTestSummaryDbo> getStudentTests, string culture);
        HashSet<StudentTestResultListDto> ConvertToWebModel2(HashSet<StudentTestSummaryDbo> getAllStudentTestResults, string culture);
        ShowTestResultDto ConvertToWebModel(StudentTestSummaryDbo showTestResult);
    }
}
