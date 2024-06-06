using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.CourseLesson
{
    [Table("Edu_CourseLessonTranslation")]
    public class CourseLessonTranslationDbo : TranslationTableModel
    {
        [Column("Name")]
        public virtual string Name { get; set; }

        public virtual CourseLessonDbo CourseLesson { get; set; }
        public virtual Guid CourseLessonId { get; set; }
    }
}
