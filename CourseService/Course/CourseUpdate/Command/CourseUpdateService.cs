using Core.Base.Command.Update;
using Core.Base.Repository.CodeBookRepository;
using CourseService.Course.CourseUpdate.Convertor;
using CourseService.Course.CourseUpdate.Dto;
using CourseService.Course.CourseUpdate.Validator;
using Model.CodeBook;
using Model.Edu.Course;
using Repository.Course;

namespace CourseService.Course.CourseUpdate.Command
{
    public class CourseUpdateService
        : BaseUpdateCommand<CourseDbo, ICourseRepository, CourseUpdateDto, ICourseUpdateConvertor, ICourseUpdateValidator>,
            ICourseUpdateService
    {
        public CourseUpdateService(
            ICourseRepository repository,
            ICourseUpdateConvertor convertor,
            ICourseUpdateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture) { }
    }
}
