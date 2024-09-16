using Core.Base.Command.Create;
using CourseService.CourseTermStudent.CourseTermStudentCreate.Dto;
using Model.Link;

namespace CourseService.CourseTermStudent.CourseTermStudentCreate.Command
{
    public interface ICourseTermStudentCreateService : IBaseCreateCommand<CourseStudentDbo, AddCourseTermStudentDto> { }
}
