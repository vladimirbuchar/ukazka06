using Core.Base.Command.Detail;
using CourseService.Course.CourseDetail.Dto;
using Model.Edu.Course;

namespace CourseService.Course.CourseDetail.Command
{
    public interface ICourseDetailService : IBaseDetailCommand<CourseDbo, CourseDetailDto> { }
}
