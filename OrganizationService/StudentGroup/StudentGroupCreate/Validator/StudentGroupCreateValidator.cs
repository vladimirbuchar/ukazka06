using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupCreate.Dto;
using Repository.Organization;
using Repository.StudentGroup;

namespace OrganizationService.StudentGroup.StudentGroupCreate.Validator
{
    public class StudentGroupCreateValidator
        : BaseCreateValidator<StudentGroupDbo, IStudentGroupRepository, StudentGroupCreateDto>,
            IStudentGroupCreateValidator
    {
        private readonly IOrganizationRepository _organizationRepository;

        public StudentGroupCreateValidator(IStudentGroupRepository repository, IOrganizationRepository organizationRepository)
            : base(repository)
        {
            _organizationRepository = organizationRepository;
        }

        public override async Task<ResultInsert> IsValid(StudentGroupCreateDto create)
        {
            ResultInsert result = new();
            if (await _organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            IsValidString(create.Name, result, MessageCategory.STUDENT_GROUP, MessageItem.STRING_IS_EMPTY);
            return await Task.FromResult(result);
        }
    }
}
