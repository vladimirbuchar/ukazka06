using Core.Base.Dto;

namespace EduServices.OrganizationSetting.Dto
{
    public class OrganizationSettingByUrlDto : ListDto
    {
        public string Name { get; set; }
        public bool FacebookLogin { get; set; }
        public bool GoogleLogin { get; set; }
        public bool PasswordReset { get; set; }
        public bool Registration { get; set; }
    }
}
