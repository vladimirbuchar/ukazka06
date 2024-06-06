using Core.Base.Service;
using EduRepository.CourseRepository;
using EduServices.Course.Convertor;
using EduServices.Course.Dto;
using EduServices.Course.Validator;
using Model.Tables.Edu.Course;

namespace EduServices.Course.Service
{
    public class CourseService(ICourseRepository courseRepository, ICourseConvertor courseConvertor, ICourseValidator validator)
        : BaseService<ICourseRepository, CourseDbo, ICourseConvertor, ICourseValidator, CourseCreateDto, CourseListInOrganizationDto, CourseDetailDto, CourseUpdateDto>(
            courseRepository,
            courseConvertor,
            validator
        ),
            ICourseService { }
}
