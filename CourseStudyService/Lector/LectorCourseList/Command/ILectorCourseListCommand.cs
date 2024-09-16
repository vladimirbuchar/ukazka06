using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.Lector.LectorCourseList.Dto;
using Model.Link;

namespace CourseStudyService.Lector.LectorCourseList.Command
{
    public interface ILectorCourseListCommand : IBaseListCommand<CourseLectorDbo, LectorCourseListDto, RequestFilter>
    {
    }
}