using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationCreate.Dto;
using Repository.Organization;
using Repository.User;

namespace OrganizationService.Organization.OrganizationCreate.Validator
{
    public class OrganizationCreateValidator
        : BaseCreateValidator<OrganizationDbo, IOrganizationRepository, OrganizationCreateDto>,
            IOrganizationCreateValidator
    {
        private readonly ICodeBookRepository<CultureDbo> _culture;
        private readonly ICodeBookRepository<CountryDbo> _country;
        private readonly IUserRepository _userRepository;
        private readonly ICodeBookRepository<AddressTypeDbo> _addressType;
        public bool ValidateUser { get; set; }

        public OrganizationCreateValidator(
            ICodeBookRepository<AddressTypeDbo> addressType,
            IUserRepository userRepository,
            ICodeBookRepository<CultureDbo> culture,
            IOrganizationRepository repository,
            ICodeBookRepository<CountryDbo> country
        )
            : base(repository)
        {
            _culture = culture;
            _country = country;
            _userRepository = userRepository;
            _addressType = addressType;
        }

        public override async Task<ResultInsert> IsValid(OrganizationCreateDto create)
        {
            ResultInsert validate = new();
            IsValidEmail(create.Email, validate, MessageCategory.ORGANIZATION, MessageItem.EMAIL_IS_NOT_VALID);
            IsValidPhoneNumber(create.PhoneNumber, validate, MessageCategory.ORGANIZATION, MessageItem.IS_NOT_VALID_PHONE_NUMBER);
            IsValidUri(create.WWW, validate, MessageCategory.ORGANIZATION, MessageItem.IS_NOT_VALID_URI);
            await ValidateAddress(create.Addresses, validate);
            IsValidString(create.Name, validate, MessageCategory.ORGANIZATION, MessageItem.STRING_IS_EMPTY);
            await CodeBookValueExist(
                _culture,
                x => x.Id == create.DefaultCultureId,
                validate,
                MessageCategory.CULTURE,
                MessageItem.NOT_EXISTS,
                create.DefaultCultureId.ToString()
            );
            if (ValidateUser && await _userRepository.GetEntity(false, x => x.Id == create.UserId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER, MessageItem.NOT_EXISTS));
            }
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
