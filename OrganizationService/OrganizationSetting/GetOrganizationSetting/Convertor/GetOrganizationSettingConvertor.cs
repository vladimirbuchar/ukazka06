using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.GetOrganizationSetting.Dto;

namespace OrganizationService.OrganizationSetting.GetOrganizationSetting.Convertor
{
    public class GetOrganizationSettingConvertor : IGetOrganizationSettingConvertor
    {
        public Task<OrganizationSettingDetailDto> ConvertToWebModel(OrganizationSettingDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new OrganizationSettingDetailDto()
                {
                    OrganizationId = detail.OrganizationId,
                    UserDefaultPassword = detail.UserDefaultPassword,
                    ElearningUrl = detail.ElearningUrl,
                    FacebookLogin = detail.FacebookLogin,
                    GoogleLogin = detail.GoogleLogin,
                    PasswordReset = detail.PasswordReset,
                    Registration = detail.Registration,
                    LessonLength = detail.LessonLength,
                    TextColor = detail.TextColor,
                    BackgroundColor = detail.BackgroundColor,
                    UseCustomSmtpServer = detail.UseCustomSmtpServer,
                    SmtpServerUserName = detail.SmtpServerUserName,
                    SmtpServerUrl = detail.SmtpServerUrl,
                    SmtpServerPort = detail.SmtpServerPort,
                    SmtpServerPassword = detail.SmtpServerPassword,
                    GoogleApiToken = detail.GoogleApiToken,
                    Id = detail.Id,
                    LicenceId = detail.Organization.LicenseId,
                }
            );
        }
    }
}
