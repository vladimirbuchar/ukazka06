using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationDetail.Dto;
using OrganizationService.Organization.OrganizationUpdate.Dto;
using Repository.Organization;

namespace OrganizationService.Organization.OrganizationUpdate.Validator
{
    public class OrganizationUpdateValidator
        : BaseUpdateValidator<OrganizationDbo, IOrganizationRepository, OrganizationUpdateDto>,
            IOrganizationUpdateValidator
    {
        private readonly ICodeBookRepository<CountryDbo> _country;
        private readonly ICodeBookRepository<AddressTypeDbo> _addressType;

        public OrganizationUpdateValidator(
            ICodeBookRepository<AddressTypeDbo> addressType,
            ICodeBookRepository<CountryDbo> country,
            IOrganizationRepository repository
        )
            : base(repository)
        {
            _country = country;
            _addressType = addressType;
        }

        public override async Task<Result> IsValid(OrganizationUpdateDto update)
        {
            Result<OrganizationDetailDto> validate = new();
            IsValidEmail(update.Email, validate, MessageCategory.ORGANIZATION, MessageItem.EMAIL_IS_NOT_VALID);
            IsValidPhoneNumber(update.PhoneNumber, validate, MessageCategory.ORGANIZATION, MessageItem.IS_NOT_VALID_PHONE_NUMBER);
            IsValidUri(update.WWW, validate, MessageCategory.ORGANIZATION, MessageItem.IS_NOT_VALID_URI);
            await ValidateAddress(update.Addresses, validate);
            IsValidString(update.Name, validate, MessageCategory.ORGANIZATION, MessageItem.STRING_IS_EMPTY);
            return validate;
        }

        private async Task ValidateAddress(List<Address> addresses, Result result)
        {
            if (addresses != null && addresses.Count > 0)
            {
                foreach (Address address in addresses)
                {
                    await base.CodeBookValueExist(
                        _country,
                        x => x.Id == address.CountryId,
                        result,
                        AddressValidator.COUNTRY,
                        AddressValidator.COUNTRY_NOT_EXIST,
                        address.CountryId.ToString()
                    );
                    await base.CodeBookValueExist(
                        _addressType,
                        x => x.Id == address.AddressTypeId,
                        result,
                        AddressValidator.ADDRESS_TYPE,
                        AddressValidator.ADDRESS_TYPE_NOT_EXIST,
                        address.AddressTypeId.ToString()
                    );
                }
            }
        }
    }
}
