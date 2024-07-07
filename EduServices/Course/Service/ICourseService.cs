using Core.Base.Service;
using Model.Edu.Course;
using Services.Course.Dto;

namespace Services.Course.Service
{
    public interface ICourseService : IBaseService<CourseDbo, CourseCreateDto, CourseListDto, CourseDetailDto, CourseUpdateDto> { }
}
