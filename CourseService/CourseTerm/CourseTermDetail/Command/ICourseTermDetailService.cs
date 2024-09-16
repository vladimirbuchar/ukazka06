using Core.Base.Command.Detail;
using CourseService.CourseTerm.CourseTermDetail.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermDetail.Command
{
    public interface ICourseTermDetailService : IBaseDetailCommand<CourseTermDbo, CourseTermDetailDto> { }
}
