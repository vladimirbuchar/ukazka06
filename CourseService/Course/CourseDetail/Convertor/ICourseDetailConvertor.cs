using Core.Base.Convertor;
using CourseService.Course.CourseDetail.Dto;
using Model.Edu.Course;

namespace CourseService.Course.CourseDetail.Convertor
{
    public interface ICourseDetailConvertor : IBaseDetailConvertor<CourseDbo, CourseDetailDto> { }
}
