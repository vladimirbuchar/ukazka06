using Core.Base.Convertor;
using Model.Edu.Course;
using Services.Course.Dto;

namespace Services.Course.Convertor
{
    public interface ICourseConvertor : IBaseConvertor<CourseDbo, CourseCreateDto, CourseListDto, CourseDetailDto, CourseUpdateDto>
    {

    }
}
