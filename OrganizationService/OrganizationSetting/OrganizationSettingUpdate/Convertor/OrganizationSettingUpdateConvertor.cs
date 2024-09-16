using Core.Extension;
using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Dto;

namespace OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Convertor
{
    public class OrganizationSettingUpdateConvertor : IOrganizationSettingUpdateConvertor
    {
        public Task<OrganizationSettingDbo> ConvertToBussinessEntity(
            OrganizationSettingUpdateDto update,
            OrganizationSettingDbo entity,
            string culture
        )
        {
            entity.UserDefaultPassword = update.UserDefaultPassword;
            entity.ElearningUrl = update.UrlElearning.ToUrl();
            entity.Registration = update.Registration;
            entity.PasswordReset = update.PasswordReset;
            entity.GoogleLogin = update.GoogleLogin;
            entity.FacebookLogin = update.FacebookLogin;
            entity.LessonLength = update.LessonLength;
            entity.BackgroundColor = update.BackgroundColor;
            entity.TextColor = update.TextColor;
            entity.SmtpServerPassword = update.SmtpServerPassword;
            entity.SmtpServerPort = update.SmtpServerPort;
            entity.SmtpServerUrl = update.SmtpServerUrl;
            entity.SmtpServerUserName = update.SmtpServerUserName;
            entity.UseCustomSmtpServer = update.UseCustomSmtpServer;
            entity.GoogleApiToken = update.GoogleApiToken;
            return Task.FromResult(entity);
        }
    }
}
