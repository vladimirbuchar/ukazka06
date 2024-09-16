using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Dto;

namespace OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Convertor
{
    public class GetOrganizationSettingByUrlConvertor : IGetOrganizationSettingByUrlConvertor
    {
        public Task<OrganizationSettingByUrlDto> ConvertToWebModel(OrganizationSettingDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new OrganizationSettingByUrlDto()
                {
                    FacebookLogin = detail.FacebookLogin,
                    GoogleLogin = detail.GoogleLogin,
                    PasswordReset = detail.PasswordReset,
                    Registration = detail.Registration,
                    Id = detail.Id,
                    Name = detail.Organization.Name
                }
            );
        }
    }
}
