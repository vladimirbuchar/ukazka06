using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.Course
{
    [Table("Edu_CourseTranslation")]
    public class CourseTranslationDbo : TranslationTableModel
    {
        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }
        public virtual CourseDbo Course { get; set; }
        public virtual Guid CourseId { get; set; }
    }
}
