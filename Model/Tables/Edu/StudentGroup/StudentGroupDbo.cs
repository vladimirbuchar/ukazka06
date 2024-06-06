using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.Organization;
using Model.Tables.Link;

namespace Model.Tables.Edu.StudentGroup
{
    [Table("Edu_StudentGroup")]
    public class StudentGroupDbo : TableModel
    {
        public virtual Guid OrganizationId { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual ICollection<StudentGroupTranslationDbo> StudentGroupTranslations { get; set; }
        public virtual ICollection<StudentInGroupCourseTermDbo> StudentInGroupCourseTerms { get; set; }
        public virtual ICollection<UserInOrganizationDbo> UserInOrganization { get; set; }
    }
}
