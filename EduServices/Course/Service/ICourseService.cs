using Core.Base.Service;
using EduServices.Course.Dto;
using Model.Tables.Edu.Course;

namespace EduServices.Course.Service
{
    public interface ICourseService : IBaseService<CourseDbo, CourseCreateDto, CourseListInOrganizationDto, CourseDetailDto, CourseUpdateDto> { }
}
