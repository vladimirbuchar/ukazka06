using Core.Base.Command.Update;
using CourseService.CourseTerm.CourseTermUpdate.Convertor;
using CourseService.CourseTerm.CourseTermUpdate.Dto;
using CourseService.CourseTerm.CourseTermUpdate.Validator;
using Model.Edu.CourseTerm;
using Repository.CourseTerm;

namespace CourseService.CourseTerm.CourseTermUpdate.Command
{
    public class CourseTermUpdateService
        : BaseUpdateCommand<CourseTermDbo, ICourseTermRepository, CourseTermUpdateDto, ICourseTermUpdateConvertor, ICourseTermUpdateValidator>,
            ICourseTermUpdateService
    {
        public CourseTermUpdateService(ICourseTermRepository repository, ICourseTermUpdateConvertor convertor, ICourseTermUpdateValidator validator)
            : base(repository, convertor, validator) { }
    }
}
