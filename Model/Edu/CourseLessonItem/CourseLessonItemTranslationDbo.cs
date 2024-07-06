using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.CourseLessonItem
{
    [Table("Edu_CourseLessonItemTranslation")]
    public class CourseLessonItemTranslationDbo : TranslationTableModel
    {
        [Column("Html")]
        public virtual string Html { get; set; }

        [Column("Name")]
        public virtual string Name { get; set; }
        public virtual CourseLessonItemDbo CourseLessonItem { get; set; }
        public virtual Guid CourseLessonItemId { get; set; }
    }
}
