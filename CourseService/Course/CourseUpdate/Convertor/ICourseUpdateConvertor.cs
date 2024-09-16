using Core.Base.Convertor;
using CourseService.Course.CourseUpdate.Dto;
using Model.Edu.Course;

namespace CourseService.Course.CourseUpdate.Convertor
{
    public interface ICourseUpdateConvertor : IBaseUpdateConvertor<CourseDbo, CourseUpdateDto> { }
}
