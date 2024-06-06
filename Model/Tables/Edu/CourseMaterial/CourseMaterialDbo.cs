using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.Course;
using Model.Tables.Edu.CourseLesson;
using Model.Tables.Edu.Organization;

namespace Model.Tables.Edu.CourseMaterial
{
    [Table("Edu_CourseMaterial")]
    public class CourseMaterialDbo : TableModel
    {
        public virtual Guid OrganizationId { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual ICollection<CourseMaterialTranslationDbo> CourseMaterialTranslation { get; set; }
        public virtual ICollection<CourseLessonDbo> CourseLessons { get; set; }
        public virtual ICollection<CourseDbo> Courses { get; set; }
        public virtual ICollection<CourseMaterialFileRepositoryDbo> CourseMaterialFileRepositories { get; set; }
    }
}
