using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.OrganizationRepository;
using EduRepository.UserRepository;
using EduServices.Organization.Dto;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Organization;
using System.Collections.Generic;

namespace EduServices.Organization.Validator
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
            IsValidEmail(create.Email, validate, ErrorCategory.ORGANIZATION, GlobalValue.EMAIL_IS_NOT_VALID);
            IsValidPhoneNumber(create.PhoneNumber, validate, ErrorCategory.ORGANIZATION, GlobalValue.IS_NOT_VALID_PHONE_NUMBER);
            IsValidUri(create.WWW, validate, ErrorCategory.ORGANIZATION, GlobalValue.IS_NOT_VALID_URI);
            ValidateAddress(create.Addresses, validate);
            IsValidString(create.Name, validate, ErrorCategory.ORGANIZATION, GlobalValue.STRING_IS_EMPTY);
            CodeBookValueExist(_culture, x => x.Id == create.DefaultCultureId, validate, ErrorCategory.CULTURE, GlobalValue.NOT_EXISTS, create.DefaultCultureId.ToString());
            if (ValidateUser && _userRepository.GetEntity(false, x => x.Id == create.UserId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.USER, GlobalValue.NOT_EXISTS));
            }
            return validate;
        }

        public override Result<OrganizationDetailDto> IsValid(OrganizationUpdateDto update)
        {
            Result<OrganizationDetailDto> validate = new();
            IsValidEmail(update.Email, validate, ErrorCategory.ORGANIZATION, GlobalValue.EMAIL_IS_NOT_VALID);
            IsValidPhoneNumber(update.PhoneNumber, validate, ErrorCategory.ORGANIZATION, GlobalValue.IS_NOT_VALID_PHONE_NUMBER);
            IsValidUri(update.WWW, validate, ErrorCategory.ORGANIZATION, GlobalValue.IS_NOT_VALID_URI);
            ValidateAddress(update.Addresses, validate);
            IsValidString(update.Name, validate, ErrorCategory.ORGANIZATION, GlobalValue.STRING_IS_EMPTY);
            return validate;
        }

        private void ValidateAddress(HashSet<Core.DataTypes.Address> addresses, Result result)
        {
            if (addresses != null && addresses.Count > 0)
            {
                foreach (Core.DataTypes.Address address in addresses)
                {
                    base.CodeBookValueExist(_country, x => x.Id == address.CountryId, result, AddressValidator.COUNTRY, AddressValidator.COUNTRY_NOT_EXIST, address.CountryId.ToString());
                    base.CodeBookValueExist(_addressType, x => x.Id == address.AddressTypeId, result, AddressValidator.ADDRESS_TYPE, AddressValidator.ADDRESS_TYPE_NOT_EXIST, address.AddressTypeId.ToString());
                }
            }
        }
    }
}
