using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace OrganizationService.OrganizationSetting.GetOrganizationSetting.Dto
{
    public class OrganizationSettingDetailDto : DetailDto
    {
        [JsonIgnore]
        public override Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public string UserDefaultPassword { get; set; } = string.Empty;
        public string ElearningUrl { get; set; } = string.Empty;
        public bool FacebookLogin { get; set; }
        public bool GoogleLogin { get; set; }
        public bool PasswordReset { get; set; }
        public bool Registration { get; set; }
        public int LessonLength { get; set; }
        public string BackgroundColor { get; set; } = string.Empty;
        public string TextColor { get; set; } = string.Empty;
        public Guid BackgroundImage { get; set; }
        public string OriginalFileName { get; set; } = string.Empty;
        public bool UseCustomSmtpServer { get; set; }
        public string SmtpServerUrl { get; set; } = string.Empty;
        public string SmtpServerUserName { get; set; } = string.Empty;
        public string SmtpServerPassword { get; set; } = string.Empty;
        public int SmtpServerPort { get; set; }
        public string GoogleApiToken { get; set; } = string.Empty;
        public Guid LicenceId { get; set; }
    }
}
