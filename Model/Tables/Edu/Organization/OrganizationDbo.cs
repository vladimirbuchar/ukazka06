using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.CodeBook;
using Model.Tables.Edu.BankOfQuestions;
using Model.Tables.Edu.Branch;
using Model.Tables.Edu.Certificate;
using Model.Tables.Edu.Course;
using Model.Tables.Edu.CourseMaterial;
using Model.Tables.Edu.LicenseChange;
using Model.Tables.Edu.Notification;
using Model.Tables.Edu.OrganizationAddress;
using Model.Tables.Edu.OrganizationSetting;
using Model.Tables.Edu.OrganizationStudyHour;
using Model.Tables.Edu.SendEmail;
using Model.Tables.Edu.SendMessage;
using Model.Tables.Edu.StudentGroup;
using Model.Tables.Link;

namespace Model.Tables.Edu.Organization
{
    [Table("Edu_Organization")]
    public class OrganizationDbo : TableModel
    {
        [Column("CanSendCourseInquiry")]
        public virtual bool CanSendCourseInquiry { get; set; }

        [Column("Email")]
        public virtual string Email { get; set; }

        [Column("PhoneNumber")]
        public virtual string PhoneNumber { get; set; }

        [Column("WWW")]
        public virtual string WWW { get; set; }
        public virtual string Name { get; set; }
        public virtual LicenseDbo License { get; set; }
        public virtual Guid LicenseId { get; set; }

        public virtual OrganizationSettingDbo OrganizationSetting { get; set; }
        public virtual Guid OrganizationSettingId { get; set; }
        public virtual ICollection<OrganizationTranslationDbo> OrganizationTranslations { get; set; }
        public virtual ICollection<BranchDbo> Branch { get; set; }
        public virtual ICollection<CourseDbo> Course { get; set; }
        public virtual ICollection<BankOfQuestionDbo> BankOfQuestions { get; set; }
        public virtual ICollection<OrganizationAddressDbo> Addresses { get; set; }
        public virtual ICollection<NotificationDbo> Notifications { get; set; }
        public virtual ICollection<CertificateDbo> Certificates { get; set; }
        public virtual ICollection<OrganizationStudyHourDbo> OrganizationStudyHours { get; set; }
        public virtual ICollection<SendMessageDbo> SendMessages { get; set; }
        public virtual ICollection<StudentGroupDbo> StudentGroups { get; set; }
        public virtual ICollection<CourseMaterialDbo> CourseMaterials { get; set; }
        public virtual ICollection<UserInOrganizationDbo> UserInOrganizations { get; set; }
        public virtual ICollection<SendEmailDbo> SendEmails { get; set; }
        public virtual ICollection<OrganizationCultureDbo> OrganizationCultures { get; set; }
        public virtual ICollection<LicenseChangeDbo> LicenseChanges { get; set; }
        public virtual ICollection<OrganizationFileRepositoryDbo> OrganizationFileRepositories { get; set; }
    }
}
