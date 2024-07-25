using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.StudentGroup;
using Repository.OrganizationRepository;
using Repository.StudentGroupRepository;
using Services.StudentGroup.Dto;
using System.Threading.Tasks;

namespace Services.StudentGroup.Validator
{
    public class StudentGroupValidator(IStudentGroupRepository repository, IOrganizationRepository organizationRepository)
        : BaseValidator<StudentGroupDbo, IStudentGroupRepository, StudentGroupCreateDto, StudentGroupDetailDto, StudentGroupUpdateDto>(repository),
            IStudentGroupValidator
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override async Task<Result> IsValid(StudentGroupCreateDto create)
        {
            Result<StudentGroupDetailDto> result = new();
            if (await _organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            IsValidString(create.Name, result, MessageCategory.STUDENT_GROUP, MessageItem.STRING_IS_EMPTY);
            return await Task.FromResult(result);
        }

        public override async Task<Result<StudentGroupDetailDto>> IsValid(StudentGroupUpdateDto update)
        {
            Result<StudentGroupDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.STUDENT_GROUP, MessageItem.STRING_IS_EMPTY);
            return await Task.FromResult(result);
        }
    }
}
