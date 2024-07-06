using Core.Base.Service;
using EduServices.Course.Dto;
using Model.Edu.Course;

namespace EduServices.Course.Service
{
    public interface ICourseService : IBaseService<CourseDbo, CourseCreateDto, CourseListDto, CourseDetailDto, CourseUpdateDto> { }
}
