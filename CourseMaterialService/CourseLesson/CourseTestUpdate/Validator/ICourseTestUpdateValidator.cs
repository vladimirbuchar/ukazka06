using Core.Base.Validator;
using CourseMaterialService.CourseLesson.CourseTestUpdate.Dto;
using Model.Edu.CourseTest;

namespace CourseMaterialService.CourseLesson.CourseTestUpdate.Validator
{
    public interface ICourseTestUpdateValidator : IBaseUpdateValidator<CourseTestDbo, CourseTestUpdateDto> { }
}
