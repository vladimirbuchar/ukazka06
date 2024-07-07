using Core.Base.Service;
using Model.Edu.Course;
using Repository.CourseRepository;
using Services.Course.Convertor;
using Services.Course.Dto;
using Services.Course.Validator;

namespace Services.Course.Service
{
    public class CourseService(ICourseRepository courseRepository, ICourseConvertor courseConvertor, ICourseValidator validator)
        : BaseService<ICourseRepository, CourseDbo, ICourseConvertor, ICourseValidator, CourseCreateDto, CourseListDto, CourseDetailDto, CourseUpdateDto>(courseRepository, courseConvertor, validator),
            ICourseService { }
}
