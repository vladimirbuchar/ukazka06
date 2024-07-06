using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.CodeBook;
using Model.Edu.CourseLesson;
using Model.Link;

namespace Model.Edu.CourseLessonItem
{
    [Table("Edu_CourseLessonItem")]
    public class CourseLessonItemDbo : TableModel
    {
        [Column("Position")]
        public virtual int Position { get; set; } = 0;

        [Column("Youtube")]
        public string Youtube { get; set; }
        public virtual CourseLessonItemTemplateDbo CourseLessonItemTemplate { get; set; }
        public virtual Guid CourseLessonItemTemplateId { get; set; }
        public virtual CourseLessonDbo CourseLesson { get; set; }
        public virtual Guid CourseLessonId { get; set; }
        public virtual ICollection<CourseLessonItemTranslationDbo> CourseLessonItemTranslations { get; set; }
        public virtual ICollection<CourseBrowseDbo> CourseBrowses { get; set; }
        public virtual ICollection<CouseStudentMaterialDbo> CouseStudentMaterials { get; set; }
        public virtual ICollection<CourseLessonItemFileRepositoryDbo> CourseLessonItemFileRepositories { get; set; }
    }
}
