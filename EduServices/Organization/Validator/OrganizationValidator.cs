using System.Collections.Generic;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Organization;
using Repository.OrganizationRepository;
using Repository.UserRepository;
using Services.Organization.Dto;

namespace Services.Organization.Validator
{
    public class OrganizationValidator(
        IOrganizationRepository repository,
        ICodeBookRepository<AddressTypeDbo> addressType,
        IUserRepository userRepository,
        ICodeBookRepository<CountryDbo> country,
        ICodeBookRepository<CultureDbo> culture
    ) : BaseValidator<OrganizationDbo, IOrganizationRepository, OrganizationCreateDto, OrganizationDetailDto, OrganizationUpdateDto>(repository), IOrganizationValidator
    {
        private readonly ICodeBookRepository<CountryDbo> _country = country;
        private readonly ICodeBookRepository<AddressTypeDbo> _addressType = addressType;
        private readonly ICodeBookRepository<CultureDbo> _culture = culture;
        private readonly IUserRepository _userRepository = userRepository;
        public bool ValidateUser { get; set; } = true;

        public override Result<OrganizationDetailDto> IsValid(OrganizationCreateDto create)
        {
            Result<OrganizationDetailDto> validate = new();
            IsValidEmail(create.Email, validate, MessageCategory.ORGANIZATION, MessageItem.EMAIL_IS_NOT_VALID);
            IsValidPhoneNumber(create.PhoneNumber, validate, MessageCategory.ORGANIZATION, MessageItem.IS_NOT_VALID_PHONE_NUMBER);
            IsValidUri(create.WWW, validate, MessageCategory.ORGANIZATION, MessageItem.IS_NOT_VALID_URI);
            ValidateAddress(create.Addresses, validate);
            IsValidString(create.Name, validate, MessageCategory.ORGANIZATION, MessageItem.STRING_IS_EMPTY);
            CodeBookValueExist(_culture, x => x.Id == create.DefaultCultureId, validate, MessageCategory.CULTURE, MessageItem.NOT_EXISTS, create.DefaultCultureId.ToString());
            if (ValidateUser && _userRepository.GetEntity(false, x => x.Id == create.UserId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER, MessageItem.NOT_EXISTS));
            }
            return validate;
        }

        public override Result<OrganizationDetailDto> IsValid(OrganizationUpdateDto update)
        {
            Result<OrganizationDetailDto> validate = new();
            IsValidEmail(update.Email, validate, MessageCategory.ORGANIZATION, MessageItem.EMAIL_IS_NOT_VALID);
            IsValidPhoneNumber(update.PhoneNumber, validate, MessageCategory.ORGANIZATION, MessageItem.IS_NOT_VALID_PHONE_NUMBER);
            IsValidUri(update.WWW, validate, MessageCategory.ORGANIZATION, MessageItem.IS_NOT_VALID_URI);
            ValidateAddress(update.Addresses, validate);
            IsValidString(update.Name, validate, MessageCategory.ORGANIZATION, MessageItem.STRING_IS_EMPTY);
            return validate;
        }

        private void ValidateAddress(HashSet<Address> addresses, Result result)
        {
            if (addresses != null && addresses.Count > 0)
            {
                foreach (Address address in addresses)
                {
                    base.CodeBookValueExist(_country, x => x.Id == address.CountryId, result, AddressValidator.COUNTRY, AddressValidator.COUNTRY_NOT_EXIST, address.CountryId.ToString());
                    base.CodeBookValueExist(
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
