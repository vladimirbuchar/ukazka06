using Core.Base.Command.Detail;
using CourseService.Course.CourseDetail.Convertor;
using CourseService.Course.CourseDetail.Dto;
using Model.Edu.Course;
using Repository.Course;

namespace CourseService.Course.CourseDetail.Command
{
    public class CourseDetailService : BaseDetailCommand<CourseDbo, ICourseRepository, CourseDetailDto, ICourseDetailConvertor>, ICourseDetailService
    {
        public CourseDetailService(ICourseRepository repository, ICourseDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
