using Core.Base.Command.Create;
using CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Dto;
using Model.Link;

namespace CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Command
{
    public interface IStudentInGroupCourseTermCreateService : IBaseCreateCommand<StudentInGroupCourseTermDbo, StudentInGroupCourseTermCreateDto> { }
}
