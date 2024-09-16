using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Microsoft.Extensions.Configuration;
using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Dto;
using Repository.OrganizationSetting;

namespace OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Validator
{
    public class OrganizationSettingUpdateValidator
        : BaseUpdateValidator<OrganizationSettingDbo, IOrganizationSettingRepository, OrganizationSettingUpdateDto>,
            IOrganizationSettingUpdateValidator
    {
        private readonly string _elearningUrl;

        public OrganizationSettingUpdateValidator(IOrganizationSettingRepository repository, IConfiguration configuration)
            : base(repository)
        {
            _elearningUrl = configuration.GetSection(ConfigValue.ELEARNING_URL).Value;
        }

        public override async Task<Result> IsValid(OrganizationSettingUpdateDto update)
        {
            Result validate = new();
            await IsValidOrganizationUrl(update.UrlElearning, update.OrganizationId, validate);
            IsValidPostiveNumber(update.LessonLength, validate, MessageCategory.ORGANIZATION, Constants.LESSON_LENGTH);
            if (update.UseCustomSmtpServer)
            {
                IsValidString(update.SmtpServerUrl, validate, MessageCategory.ORGANIZATION, Constants.SMTP_SERVER);
                IsValidString(update.SmtpServerUserName, validate, MessageCategory.ORGANIZATION, Constants.SMTP_LOGIN);
                IsValidString(update.SmtpServerPassword, validate, MessageCategory.ORGANIZATION, Constants.SMTP_PASSWORD);
                IsValidPostiveNumber(update.SmtpServerPort, validate, MessageCategory.ORGANIZATION, Constants.SMTP_PORT);
            }
            return validate;
        }

        private async Task IsValidOrganizationUrl(string url, Guid organizationId, Result result)
        {
            if (url.IsNullOrEmptyWithTrim() || url == _elearningUrl)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, Constants.ELEARNIG_BAD_EMPTY_URL));
            }
            if (await _repository.GetEntity(false, x => x.ElearningUrl == url && x.OrganizationId != organizationId) != null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, Constants.ELEARNIG_URL_EXISTS, url));
            }
            if (!url.IsValidUri())
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, Constants.ELEARNIG_IS_NOT_VALID, url));
            }
        }
    }
}
