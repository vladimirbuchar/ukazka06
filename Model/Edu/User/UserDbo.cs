using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.Chat;
using Model.Edu.LinkLifeTime;
using Model.Edu.Note;
using Model.Edu.Notification;
using Model.Edu.Person;
using Model.Edu.UserCertificate;
using Model.Edu.UserRole;
using Model.Link;

namespace Model.Edu.User
{
    [Table("Edu_User")]
    public class UserDbo : TableModel
    {
        [Column("UserEmail")]
        public virtual string UserEmail { get; set; }

        [Column("UserPassword")]
        public virtual string UserPassword { get; set; }

        [Column("FacebookId")]
        public virtual string FacebookId { get; set; }

        [Column("GoogleId")]
        public virtual string GoogleId { get; set; }

        [Column("UserMustChangePassword")]
        public virtual bool UserMustChangePassword { get; set; }

        [Column("AllowCLassicLogin")]
        public virtual bool AllowCLassicLogin { get; set; } = true;
        public virtual PersonDbo Person { get; set; }
        public virtual Guid PersonId { get; set; }

        public virtual UserRoleDbo UserRole { get; set; }
        public virtual Guid? UserRoleId { get; set; }

        public virtual IEnumerable<LinkLifeTimeDbo> LinkLifeTime { get; set; }
        public virtual IEnumerable<UserCertificateDbo> UserCertificates { get; set; }
        public virtual IEnumerable<CourseBrowseDbo> CourseBrowses { get; set; }
        public virtual IEnumerable<UserInOrganizationDbo> UserInOrganizations { get; set; }
        public virtual IEnumerable<CouseStudentMaterialDbo> CouseStudentMaterials { get; set; }
        public virtual IEnumerable<ChatDbo> Chats { get; set; }
        public virtual IEnumerable<NotificationDbo> Notifications { get; set; }
        public virtual IEnumerable<NoteDbo> Notes { get; set; }
    }
}
