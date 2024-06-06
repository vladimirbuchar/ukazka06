using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using EduRepository.OrganizationRepository;
using EduRepository.OrganizationSettingRepository;
using EduRepository.UserRepository;
using EduServices.Organization.Dto;
using EduServices.OrganizationSetting.Dto;
using Microsoft.Extensions.Configuration;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Organization;
using System;
using System.Collections.Generic;

namespace EduServices.OrganizationSetting.Validator
{
    public class OrganizationSettingValidator(
        IOrganizationSettingRepository organizationSettingRepository,
        IConfiguration configuration,
        IOrganizationRepository repository,
        ICodeBookRepository<AddressTypeDbo> addressType,
        IUserRepository userRepository,
        ICodeBookRepository<CountryDbo> country
    ) : BaseValidator<OrganizationDbo, IOrganizationRepository, OrganizationCreateDto, OrganizationDetailDto, OrganizationUpdateDto>(repository), IOrganizationSettingValidator
    {
        private readonly ICodeBookRepository<CountryDbo> _country = country;
        private readonly ICodeBookRepository<AddressTypeDbo> _addressType = addressType;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IOrganizationSettingRepository _organizationSettingRepository = organizationSettingRepository;
        private readonly string _elearningUrl = configuration.GetSection(ConfigValue.ElearningUrl).Value;

        public override Result<OrganizationDetailDto> IsValid(OrganizationCreateDto create)
        {
            Result<OrganizationDetailDto> validate = new();
            IsValidEmail(create.Email, validate, ErrorCategory.ORGANIZATION, GlobalValue.EMAIL_IS_NOT_VALID);
            IsValidPhoneNumber(create.PhoneNumber, validate, ErrorCategory.ORGANIZATION, GlobalValue.IS_NOT_VALID_PHONE_NUMBER);
            IsValidUri(create.WWW, validate, ErrorCategory.ORGANIZATION, GlobalValue.IS_NOT_VALID_URI);
            ValidateAddress(create.Addresses, validate);
            IsValidString(create.Name, validate, ErrorCategory.ORGANIZATION, GlobalValue.STRING_IS_EMPTY);
            if (_userRepository.GetEntity(false, x => x.Id == create.UserId) == null)
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

        private void IsValidOrganizationUrl(string url, Guid organizationId, Result result)
        {
            if (url.IsNullOrEmptyWithTrim() || url == _elearningUrl)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.ORGANIZATION, Constants.ELEARNIG_BAD_EMPTY_URL));
            }
            if (_organizationSettingRepository.GetEntities(false, x => x.ElearningUrl == url && x.OrganizationId != organizationId).Count > 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.ORGANIZATION, Constants.ELEARNIG_URL_EXISTS, url));
            }
            if (!url.IsValidUri())
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.ORGANIZATION, Constants.ELEARNIG_IS_NOT_VALID, url));
            }
        }

        public Result IsValid(OrganizationSettingUpdateDto saveOrganizationSettingDto)
        {
            Result validate = new();
            //CodeBookValueExist<CultureDbo>(_culture,x=>x.Id == saveOrganizationSettingDto.DefaultCulture,validate,Constants.ORGANIZATION , "BAD_DEFAULT_CULTURE");
            IsValidOrganizationUrl(saveOrganizationSettingDto.UrlElearning, saveOrganizationSettingDto.OrganizationId, validate);
            IsValidPostiveNumber(saveOrganizationSettingDto.LessonLength, validate, ErrorCategory.ORGANIZATION, Constants.LESSON_LENGTH);
            if (saveOrganizationSettingDto.UseCustomSmtpServer)
            {
                IsValidString(saveOrganizationSettingDto.SmtpServerUrl, validate, ErrorCategory.ORGANIZATION, Constants.SMTP_SERVER);
                IsValidString(saveOrganizationSettingDto.SmtpServerUserName, validate, ErrorCategory.ORGANIZATION, Constants.SMTP_LOGIN);
                IsValidString(saveOrganizationSettingDto.SmtpServerPassword, validate, ErrorCategory.ORGANIZATION, Constants.SMTP_PASSWORD);
                IsValidString(saveOrganizationSettingDto.SmtpServerPort, validate, ErrorCategory.ORGANIZATION, Constants.SMTP_PORT);
            }
            return validate;
        }

        private void ValidateAddress(HashSet<Address> addresses, Result result)
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
