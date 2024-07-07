using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.Organization;

namespace Model.Edu.OrganizationSetting
{
    [Table("Edu_OrganizationSetting")]
    public class OrganizationSettingDbo : TableModel
    {
        [Column("UserDefaultPassword")]
        public virtual string UserDefaultPassword { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual Guid OrganizationId { get; set; }

        [Column("ElearningUrl")]
        public virtual string ElearningUrl { get; set; }

        [Column("BackgroundColor")]
        public string BackgroundColor { get; set; }

        [Column("FacebookLogin")]
        public bool FacebookLogin { get; set; }

        [Column("GoogleLogin")]
        public bool GoogleLogin { get; set; }

        [Column("PasswordReset")]
        public bool PasswordReset { get; set; }

        [Column("Registration")]
        public bool Registration { get; set; }

        [Column("LessonLength")]
        public int LessonLength { get; set; }

        [Column("TextColor")]
        public string TextColor { get; set; }

        [Column("UseCustomSmtpServer")]
        public bool UseCustomSmtpServer { get; set; }

        [Column("SmtpServerUrl")]
        public string SmtpServerUrl { get; set; }

        [Column("SmtpServerUserName")]
        public string SmtpServerUserName { get; set; }

        [Column("SmtpServerPassword")]
        public string SmtpServerPassword { get; set; }

        [Column("SmtpServerPort")]
        public int SmtpServerPort { get; set; }

        [Column("GoogleApiToken")]
        public string GoogleApiToken { get; set; }
    }
}
