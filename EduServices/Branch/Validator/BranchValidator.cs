using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Branch;
using Repository.BranchRepository;
using Repository.OrganizationRepository;
using Services.Branch.Dto;

namespace Services.Branch.Validator
{
    public class BranchValidator(IBranchRepository repository, IOrganizationRepository organizationRepository, ICodeBookRepository<CountryDbo> country)
        : BaseValidator<BranchDbo, IBranchRepository, BranchCreateDto, BranchDetailDto, BranchUpdateDto>(repository),
            IBranchValidator
    {
        private readonly ICodeBookRepository<CountryDbo> _country = country;
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override Result<BranchDetailDto> IsValid(BranchCreateDto create)
        {
            Result<BranchDetailDto> validate = new();
            IsValidEmail(create.Email, validate, MessageCategory.BRANCH, MessageItem.EMAIL_IS_NOT_VALID);
            IsValidUri(create.WWW, validate, MessageCategory.BRANCH, MessageItem.IS_NOT_VALID_URI);
            IsValidPhoneNumber(create.PhoneNumber, validate, MessageCategory.BRANCH, MessageItem.IS_NOT_VALID_PHONE_NUMBER);
            IsValidString(create.Name, validate, MessageCategory.BRANCH, MessageItem.STRING_IS_EMPTY);
            if (_organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            if (create.CountryId.HasValue)
            {
                base.CodeBookValueExist(_country, x => x.Id == create.CountryId, validate, AddressValidator.COUNTRY, AddressValidator.COUNTRY_NOT_EXIST, create.CountryId.ToString());
            }

            return validate;
        }

        public override Result<BranchDetailDto> IsValid(BranchUpdateDto update)
        {
            Result<BranchDetailDto> validate = new();
            IsValidEmail(update.Email, validate, MessageCategory.BRANCH, MessageItem.EMAIL_IS_NOT_VALID);
            IsValidUri(update.WWW, validate, MessageCategory.BRANCH, MessageItem.IS_NOT_VALID_URI);
            IsValidPhoneNumber(update.PhoneNumber, validate, MessageCategory.BRANCH, MessageItem.IS_NOT_VALID_PHONE_NUMBER);
            IsValidString(update.Name, validate, MessageCategory.BRANCH, MessageItem.STRING_IS_EMPTY);
            if (update.CountryId.HasValue)
            {
                base.CodeBookValueExist(_country, x => x.Id == update.CountryId, validate, AddressValidator.COUNTRY, AddressValidator.COUNTRY_NOT_EXIST, update.CountryId.ToString());
            }

            return validate;
        }
    }
}
