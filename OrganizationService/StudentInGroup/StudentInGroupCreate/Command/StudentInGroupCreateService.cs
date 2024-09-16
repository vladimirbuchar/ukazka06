using Core.Base.Command.Create;
using Core.DataTypes;
using Model.Link;
using OrganizationService.StudentInGroup.StudentInGroupCreate.Dto;
using OrganizationService.StudentInGroup.StudentInGroupCreate.Validator;
using Repository.CourseStudent;
using Repository.StudentGroup;
using Repository.StudentInGroup;
using Repository.StudentInGroupCourseTerm;

namespace OrganizationService.StudentInGroup.StudentInGroupCreate.Command
{
    public class StudentInGroupCreateService(
        IStudentGroupRepository studentGroupRepository,
        ICourseStudentRepository courseStudentRepository,
        IStudentInGroupCourseTermRepository studentInGroupCourseTermRepository,
        IStudentInGroupRepository repository,
        IStudentInGroupCreateValidator validator
        )
                : BaseCreateCommand<StudentInGroupDbo, IStudentInGroupRepository, AddStudentToStudentGroup, IStudentInGroupCreateValidator>(repository, validator),
            IStudentInGroupCreateService
    {
        private readonly IStudentInGroupCourseTermRepository _studentInGroupCourseTermRepository = studentInGroupCourseTermRepository;
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;
        private readonly IStudentGroupRepository _studentGroupRepository = studentGroupRepository;

        public override async Task<ResultInsert> Execute(AddStudentToStudentGroup addObject, Guid userId, string culture)
        {
            ResultInsert result = new();
            _ = await _repository.CreateEntity(
                new StudentInGroupDbo() { UserInOrganizationId = addObject.UserInOrganizationId, StudentGroupId = addObject.StudentGroupId },
                userId
            );
            List<StudentInGroupCourseTermDbo> getAllTermInGroups = await _studentInGroupCourseTermRepository.GetEntities(
                false,
                x => x.StudentGroupId == addObject.StudentGroupId
            );
            foreach (StudentInGroupCourseTermDbo item in getAllTermInGroups)
            {
                _ = await _courseStudentRepository.CreateEntity(
                    new CourseStudentDbo() { CourseTermId = item.CourseTermId, UserInOrganizationId = addObject.UserInOrganizationId },
                    userId
                );
            }
            return result;
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _studentGroupRepository.GetOrganizationId(objectId);
        }
    }
}
