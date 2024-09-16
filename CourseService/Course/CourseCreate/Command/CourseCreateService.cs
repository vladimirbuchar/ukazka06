using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using CourseService.Course.CourseCreate.Convertor;
using CourseService.Course.CourseCreate.Dto;
using CourseService.Course.CourseCreate.Validator;
using Model.CodeBook;
using Model.Edu.Course;
using Repository.Course;

namespace CourseService.Course.CourseCreate.Command
{
    public class CourseCreateService(
        ICourseRepository repository,
        ICourseCreateConvertor convertor,
        ICourseCreateValidator validator,
        ICodeBookRepository<CultureDbo> culture
        )
                : BaseCreateCommand<CourseDbo, ICourseRepository, CourseCreateDto, ICourseCreateConvertor, ICourseCreateValidator>(repository, convertor, validator, culture),
            ICourseCreateService
    {

    }
}
