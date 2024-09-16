using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.Student.StudentCourseList.Dto;
using Model.Link;

namespace CourseStudyService.Student.StudentCourseList.Command
{
    public interface IStudentCourseListCommand : IBaseListCommand<CourseStudentDbo, StudentCourseListDto, RequestFilter>
    {

    }
}