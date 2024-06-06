using Core.Base.Service;
using Core.DataTypes;
using EduServices.Test.Dto;
using System;

namespace EduServices.Test.Service
{
    public interface ITestService : IBaseService
    {
        Result<CourseTestDetailDto> AddCourseTest(CourseTestCreateDto addCourseTestDto, string culture);
        Result<CourseTestDetailDto> UpdateCourseTest(CourseTestUpdateDto updateCourseTestDto, string culture);
        CourseTestDetailDto GetCourseTestDetail(Guid courseLessonId, string culture = "");
    }
}
