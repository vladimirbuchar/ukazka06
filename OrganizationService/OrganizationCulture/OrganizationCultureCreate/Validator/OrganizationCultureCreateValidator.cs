using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureCreate.Dto;
using Repository.Organization;
using Repository.OrganizationCulture;

namespace OrganizationService.OrganizationCulture.OrganizationCultureCreate.Validator
{
    public class OrganizationCultureCreateValidator
        : BaseCreateValidator<OrganizationCultureDbo, IOrganizationCultureRepository, OrganizationCultureCreateDto>,
            IOrganizationCultureCreateValidator
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICodeBookRepository<CultureDbo> _culture;

        public OrganizationCultureCreateValidator(
            ICodeBookRepository<CultureDbo> culture,
            IOrganizationRepository organizationRepository,
            IOrganizationCultureRepository repository
        )
            : base(repository)
        {
            _organizationRepository = organizationRepository;
            _culture = culture;
        }

        public override async Task<ResultInsert> IsValid(OrganizationCultureCreateDto create)
        {
            ResultInsert validate = new();
            if (await _organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            if (await _culture.GetEntity(create.CultureId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.CULTURE, MessageItem.NOT_EXISTS));
            }
            if (await _repository.GetTotalCount(false, x => x.OrganizationId == create.OrganizationId && x.CultureId == create.CultureId) > 0)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION_CULTURE, MessageItem.EXISTS));
            }
            return validate;
        }
    }
}
