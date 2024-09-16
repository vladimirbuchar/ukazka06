using Core.Base.Command.Update;
using CourseStudyService.CourseStudy.ResetCourse.Dto;
using Model.Link;

namespace CourseStudyService.CourseStudy.ResetCourse.Command
{
    public interface IResetCourseCommand : IBaseUpdateCommand<CourseStudentDbo, ResetCourseDto>
    {
    }
}