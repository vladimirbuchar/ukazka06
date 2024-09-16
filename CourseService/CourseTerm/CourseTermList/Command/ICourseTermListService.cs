using Core.Base.Command.List;
using CourseService.CourseTerm.CourseTermList.Dto;
using CourseService.CourseTerm.CourseTermList.Filter;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermList.Command
{
    public interface ICourseTermListService : IBaseListCommand<CourseTermDbo, CourseTermListDto, CourseTermFilter> { }
}
