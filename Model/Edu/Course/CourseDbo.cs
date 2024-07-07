using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.CodeBook;
using Model.Edu.Certificate;
using Model.Edu.CourseMaterial;
using Model.Edu.CourseTerm;
using Model.Edu.Note;
using Model.Edu.Organization;
using Model.Edu.SendMessage;
using Model.Link;

namespace Model.Edu.Course
{
    [Table("Edu_Course")]
    public class CourseDbo : TableModel
    {
        [Column("IsPrivateCourse")]
        public virtual bool IsPrivateCourse { get; set; } = false;

        [Column("Price")]
        public virtual double Price { get; set; }

        [Column("Sale")]
        public virtual int Sale { get; set; }

        [Column("MinimumStudent")]
        public virtual int MinimumStudent { get; set; }

        [Column("MaximumStudent")]
        public virtual int MaximumStudent { get; set; }

        [Column("AutomaticGenerateCertificate")]
        public virtual bool AutomaticGenerateCertificate { get; set; }

        [Column("SendEmail")]
        public virtual bool SendEmail { get; set; }

        [Column("CourseWithLector")]
        public virtual bool CourseWithLector { get; set; }
        public virtual CourseTypeDbo CourseType { get; set; }
        public virtual Guid CourseTypeId { get; set; }
        public virtual CourseStatusDbo CourseStatus { get; set; }
        public virtual Guid CourseStatusId { get; set; }
        public virtual CertificateDbo Certificate { get; set; }
        public virtual Guid? CertificateId { get; set; }
        public virtual CourseMaterialDbo CourseMaterial { get; set; }
        public virtual Guid? CourseMaterialId { get; set; }
        public virtual MessageDbo SendMessage { get; set; }
        public virtual Guid? SendMessageId { get; set; }
        public virtual Guid OrganizationId { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual ICollection<CourseTranslationDbo> CourseTranslations { get; set; }
        public virtual ICollection<CourseTermDbo> CourseTerm { get; set; }
        public virtual ICollection<CourseBrowseDbo> CourseBrowses { get; set; }
        public virtual ICollection<NoteDbo> Notes { get; set; }
    }
}
