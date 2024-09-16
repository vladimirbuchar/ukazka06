using Core.Base.Dto;

namespace OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Dto
{
    public class OrganizationSettingByUrlDto : DetailDto
    {
        public string? Name { get; set; }
        public bool FacebookLogin { get; set; }
        public bool GoogleLogin { get; set; }
        public bool PasswordReset { get; set; }
        public bool Registration { get; set; }
    }
}
