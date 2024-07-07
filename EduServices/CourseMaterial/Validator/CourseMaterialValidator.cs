using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterialRepository;
using Repository.OrganizationRepository;
using Services.CourseMaterial.Dto;

namespace Services.CourseMaterial.Validator
{
    public class CourseMaterialValidator(ICourseMaterialRepository repository, IOrganizationRepository organizationRepository)
        : BaseValidator<CourseMaterialDbo, ICourseMaterialRepository, CourseMaterialCreateDto, CourseMaterialDetailDto, CourseMaterialUpdateDto>(repository),
            ICourseMaterialValidator
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override Result<CourseMaterialDetailDto> IsValid(CourseMaterialCreateDto create)
        {
            Result<CourseMaterialDetailDto> result = new();
            IsValidString(create.Name, result, MessageCategory.COURSE_MATERIAL, MessageItem.STRING_IS_EMPTY);
            if (_organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            return result;
        }

        public override Result<CourseMaterialDetailDto> IsValid(CourseMaterialUpdateDto update)
        {
            Result<CourseMaterialDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.COURSE_MATERIAL, MessageItem.STRING_IS_EMPTY);
            return result;
        }
    }
}
