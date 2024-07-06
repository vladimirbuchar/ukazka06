using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.CourseMaterialRepository;
using EduRepository.OrganizationRepository;
using EduServices.CourseMaterial.Dto;
using Model.Edu.CourseMaterial;

namespace EduServices.CourseMaterial.Validator
{
    public class CourseMaterialValidator(ICourseMaterialRepository repository, IOrganizationRepository organizationRepository)
        : BaseValidator<CourseMaterialDbo, ICourseMaterialRepository, CourseMaterialCreateDto, CourseMaterialDetailDto, CourseMaterialUpdateDto>(repository),
            ICourseMaterialValidator
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override Result<CourseMaterialDetailDto> IsValid(CourseMaterialCreateDto create)
        {
            Result<CourseMaterialDetailDto> result = new();
            IsValidString(create.Name, result, Category.COURSE_MATERIAL, GlobalValue.STRING_IS_EMPTY);
            if (_organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.ORGANIZATION, GlobalValue.NOT_EXISTS));
            }
            return result;
        }

        public override Result<CourseMaterialDetailDto> IsValid(CourseMaterialUpdateDto update)
        {
            Result<CourseMaterialDetailDto> result = new();
            IsValidString(update.Name, result, Category.COURSE_MATERIAL, GlobalValue.STRING_IS_EMPTY);
            return result;
        }
    }
}
