﻿using System.Collections.Generic;
using Core.Base.Convertor;
using EduServices.Course.Dto;
using EduServices.CourseStudy.Dto;
using Model.Tables.Edu.Course;
using Model.Tables.Edu.StudentTestSummary;

namespace EduServices.CourseStudy.Convertor
{
    public interface ICourseStudyConvertor : IBaseConvertor<CourseDbo, CourseCreateDto, CourseListInOrganizationDto, CourseDetailDto, CourseUpdateDto>
    {
        HashSet<StudentTestListDto> ConvertToWebModel(HashSet<StudentTestSummaryDbo> getStudentTests, string culture);
        HashSet<StudentTestResultListDto> ConvertToWebModel2(HashSet<StudentTestSummaryDbo> getAllStudentTestResults, string culture);
        ShowTestResultDto ConvertToWebModel(StudentTestSummaryDbo showTestResult);
    }
}
