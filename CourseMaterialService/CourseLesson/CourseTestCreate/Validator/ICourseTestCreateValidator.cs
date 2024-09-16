using Core.Base.Validator;
using CourseMaterialService.CourseLesson.CourseTestCreate.Dto;
using Model.Edu.CourseTest;

namespace CourseMaterialService.CourseLesson.CourseTestCreate.Validator
{
    public interface ICourseTestCreateValidator : IBaseCreateValidator<CourseTestDbo, CourseTestCreateDto> { }
}
