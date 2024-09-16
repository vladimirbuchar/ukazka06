using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchCreate.Dto;
using Repository.Branch;
using Repository.Organization;

namespace OrganizationService.Branch.BranchCreate.Validator
{
    public class BranchCreateValidator : BaseCreateValidator<BranchDbo, IBranchRepository, BranchCreateDto>, IBranchCreateValidator
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICodeBookRepository<CountryDbo> _country;

        public BranchCreateValidator(
            IBranchRepository repository,
            IOrganizationRepository organizationRepository,
            ICodeBookRepository<CountryDbo> country
        )
            : base(repository)
        {
            _organizationRepository = organizationRepository;
            _country = country;
        }

        public override async Task<ResultInsert> IsValid(BranchCreateDto create)
        {
            ResultInsert validate = new();
            IsValidEmail(create.Email, validate, MessageCategory.BRANCH, MessageItem.EMAIL_IS_NOT_VALID);
            IsValidUri(create.WWW, validate, MessageCategory.BRANCH, MessageItem.IS_NOT_VALID_URI);
            IsValidPhoneNumber(create.PhoneNumber, validate, MessageCategory.BRANCH, MessageItem.IS_NOT_VALID_PHONE_NUMBER);
            IsValidString(create.Name, validate, MessageCategory.BRANCH, MessageItem.STRING_IS_EMPTY);
            if (await _organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            if (create.CountryId.HasValue)
            {
                await base.CodeBookValueExist(
                    _country,
                    x => x.Id == create.CountryId,
                    validate,
                    AddressValidator.COUNTRY,
                    AddressValidator.COUNTRY_NOT_EXIST,
                    create.CountryId.ToString()
                );
            }

            return validate;
        }
    }
}
