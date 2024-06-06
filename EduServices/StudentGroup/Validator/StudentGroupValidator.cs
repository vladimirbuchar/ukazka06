using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.OrganizationRepository;
using EduRepository.StudentGroupRepository;
using EduServices.StudentGroup.Dto;
using Model.Tables.Edu.StudentGroup;

namespace EduServices.StudentGroup.Validator
{
    public class StudentGroupValidator(IStudentGroupRepository repository, IOrganizationRepository organizationRepository)
        : BaseValidator<StudentGroupDbo, IStudentGroupRepository, StudentGroupCreateDto, StudentGroupDetailDto, StudentGroupUpdateDto>(repository),
            IStudentGroupValidator
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override Result<StudentGroupDetailDto> IsValid(StudentGroupCreateDto create)
        {
            Result<StudentGroupDetailDto> result = new();
            if (_organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.ORGANIZATION, GlobalValue.NOT_EXISTS));
            }
            IsValidString(create.Name, result, ErrorCategory.STUDENT_GROUP, GlobalValue.STRING_IS_EMPTY);
            return result;
        }

        public override Result<StudentGroupDetailDto> IsValid(StudentGroupUpdateDto update)
        {
            Result<StudentGroupDetailDto> result = new();
            IsValidString(update.Name, result, ErrorCategory.STUDENT_GROUP, GlobalValue.STRING_IS_EMPTY);
            return result;
        }
    }
}
