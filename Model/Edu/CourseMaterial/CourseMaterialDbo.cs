using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.Course;
using Model.Edu.CourseLesson;
using Model.Edu.Organization;

namespace Model.Edu.CourseMaterial
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
