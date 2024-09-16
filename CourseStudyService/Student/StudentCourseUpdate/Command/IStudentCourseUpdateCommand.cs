using Core.Base.Command.Update;
using CourseStudyService.Student.StudentCourseUpdate.Dto;
using Model.Link;

namespace CourseStudyService.Student.StudentCourseUpdate.Command
{
    public interface IStudentCourseUpdateCommand : IBaseUpdateCommand<CourseStudentDbo, StudentCourseUpdateDto>
    {
    }
}