using Core.Base.Service;
using Core.DataTypes;
using Services.Test.Dto;
using System;
using System.Threading.Tasks;

namespace Services.Test.Service
{
    public interface ITestService : IBaseService
    {
        Task<Result<CourseTestDetailDto>> AddCourseTest(CourseTestCreateDto addCourseTestDto, string culture);
        Task<Result<CourseTestDetailDto>> UpdateCourseTest(CourseTestUpdateDto updateCourseTestDto, string culture);
        Task<CourseTestDetailDto> GetCourseTestDetail(Guid courseLessonId, string culture = "");
    }
}
