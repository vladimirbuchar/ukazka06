using Core.Base.Command.Detail;
using CourseService.CourseTerm.CourseTermDetail.Convertor;
using CourseService.CourseTerm.CourseTermDetail.Dto;
using Model.Edu.CourseTerm;
using Repository.CourseTerm;

namespace CourseService.CourseTerm.CourseTermDetail.Command
{
    public class CourseTermDetailService
        : BaseDetailCommand<CourseTermDbo, ICourseTermRepository, CourseTermDetailDto, ICourseTermDetailConvertor>,
            ICourseTermDetailService
    {
        public CourseTermDetailService(ICourseTermRepository repository, ICourseTermDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
