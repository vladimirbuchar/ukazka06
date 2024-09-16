using Core.Base.Command.Create;
using CourseService.CourseTerm.CourseTermCreate.Convertor;
using CourseService.CourseTerm.CourseTermCreate.Dto;
using CourseService.CourseTerm.CourseTermCreate.Validator;
using Model.Edu.CourseTerm;
using Repository.Course;
using Repository.CourseTerm;

namespace CourseService.CourseTerm.CourseTermCreate.Command
{
    public class CourseTermCreateService
        : BaseCreateCommand<CourseTermDbo, ICourseTermRepository, CourseTermCreateDto, ICourseTermCreateConvertor, ICourseTermCreateValidator>,
            ICourseTermCreateService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseTermCreateService(
            ICourseRepository courseRepository,
            ICourseTermRepository repository,
            ICourseTermCreateConvertor convertor,
            ICourseTermCreateValidator validator
        )
            : base(repository, convertor, validator)
        {
            _courseRepository = courseRepository;
        }

        public override Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return _courseRepository.GetOrganizationId(objectId);
        }
    }
}
