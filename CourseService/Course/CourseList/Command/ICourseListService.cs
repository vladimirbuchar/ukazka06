using Core.Base.Command.List;
using CourseService.Course.CourseList.Dto;
using CourseService.Course.CourseList.Filter;
using Model.Edu.Course;

namespace CourseService.Course.CourseList.Command
{
    public interface ICourseListService : IBaseListCommand<CourseDbo, CourseListDto, CourseFilter> { }
}
