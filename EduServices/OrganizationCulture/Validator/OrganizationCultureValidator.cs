using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Link;
using Repository.OrganizationCultureRepository;
using Repository.OrganizationRepository;
using Services.OrganizationCulture.Dto;

namespace Services.OrganizationCulture.Validator
{
    public class OrganizationCultureValidator(
        IOrganizationCultureRepository repository,
        IOrganizationRepository organizationRepository,
        ICodeBookRepository<CultureDbo> culture
    )
        : BaseValidator<
            OrganizationCultureDbo,
            IOrganizationCultureRepository,
            OrganizationCultureCreateDto,
            OrganizationCultureDetailDto,
            OrganizationCultureUpdateDto
        >(repository),
            IOrganizationCultureValidator
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;
        private readonly ICodeBookRepository<CultureDbo> _culture = culture;

        public override Result<OrganizationCultureDetailDto> IsValid(OrganizationCultureCreateDto create)
        {
            Result<OrganizationCultureDetailDto> validate = new();
            if (_organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            if (_culture.GetEntity(create.CultureId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.CULTURE, MessageItem.NOT_EXISTS));
            }
            return validate;
        }
    }
}
