using Core.Base.Validator;
using CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Dto;
using Model.Link;

namespace CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Validator
{
    public interface IStudentInGroupCourseTermCreateValidator
        : IBaseCreateValidator<StudentInGroupCourseTermDbo, StudentInGroupCourseTermCreateDto>
    { }
}
