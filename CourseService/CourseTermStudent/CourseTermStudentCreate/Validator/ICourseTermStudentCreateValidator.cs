using Core.Base.Validator;
using CourseService.CourseTermStudent.CourseTermStudentCreate.Dto;
using Model.Link;

namespace CourseService.CourseTermStudent.CourseTermStudentCreate.Validator
{
    public interface ICourseTermStudentCreateValidator : IBaseCreateValidator<CourseStudentDbo, AddCourseTermStudentDto> { }
}
