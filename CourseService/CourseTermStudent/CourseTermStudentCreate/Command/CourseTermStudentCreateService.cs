using Core.Base.Command.Create;
using CourseService.CourseTermStudent.CourseTermStudentCreate.Convertor;
using CourseService.CourseTermStudent.CourseTermStudentCreate.Dto;
using CourseService.CourseTermStudent.CourseTermStudentCreate.Validator;
using Model.Link;
using Repository.CourseStudent;
using Repository.CourseTerm;

namespace CourseService.CourseTermStudent.CourseTermStudentCreate.Command
{
    public class CourseTermStudentCreateService
        : BaseCreateCommand<
            CourseStudentDbo,
            ICourseStudentRepository,
            AddCourseTermStudentDto,
            ICourseTermStudentCreateConvertor,
            ICourseTermStudentCreateValidator
        >,
            ICourseTermStudentCreateService
    {
        private readonly ICourseTermRepository _courseTermRepository;

        public CourseTermStudentCreateService(
            ICourseTermRepository courseTermRepository,
            ICourseStudentRepository repository,
            ICourseTermStudentCreateValidator validator,
            ICourseTermStudentCreateConvertor convertor
        )
            : base(repository, convertor, validator)
        {
            _courseTermRepository = courseTermRepository;
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _courseTermRepository.GetOrganizationId(objectId);
        }
    }
}
