using Model.CodeBook;
using Model.Edu.BankOfQuestions;
using Model.Edu.Branch;
using Model.Edu.Certificate;
using Model.Edu.Course;
using Model.Edu.CourseMaterial;
using Model.Edu.LicenseChange;
using Model.Edu.Notification;
using Model.Edu.OrganizationAddress;
using Model.Edu.OrganizationSetting;
using Model.Edu.OrganizationStudyHour;
using Model.Edu.SendEmail;
using Model.Edu.SendMessage;
using Model.Edu.StudentGroup;
using Model.Link;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.Organization
{
    [Table("Edu_Organization")]
    public class OrganizationDbo : TableModel
    {
        [Column("Email")]
        public virtual string Email { get; set; }

        [Column("PhoneNumber")]
        public virtual string PhoneNumber { get; set; }

        [Column("WWW")]
        public virtual string WWW { get; set; }
        [Column("Name")]
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
