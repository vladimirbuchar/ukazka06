using Core.Base.Convertor;
using CourseService.Course.CourseList.Dto;
using Model.Edu.Course;

namespace CourseService.Course.CourseList.Convertor
{
    public interface ICourseListConvertor : IBaseListConvertor<CourseDbo, CourseListDto> { }
}
