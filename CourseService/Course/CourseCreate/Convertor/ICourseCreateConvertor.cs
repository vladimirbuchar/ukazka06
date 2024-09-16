using Core.Base.Convertor;
using CourseService.Course.CourseCreate.Dto;
using Model.Edu.Course;

namespace CourseService.Course.CourseCreate.Convertor
{
    public interface ICourseCreateConvertor : IBaseCreateConvertor<CourseDbo, CourseCreateDto> { }
}
