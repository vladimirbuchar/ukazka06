using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.CourseLessonItem;
using Model.Edu.CourseMaterial;
using Model.Edu.CourseTest;

namespace Model.Edu.CourseLesson
{
    [Table("Edu_CourseLesson")]
    public class CourseLessonDbo : TableModel
    {
        [Column("Position")]
        public virtual int Position { get; set; } = 0;

        [Column("Type")]
        public virtual string Type { get; set; }
        public virtual CourseMaterialDbo CourseMaterial { get; set; }
        public virtual Guid CourseMaterialId { get; set; }
        public virtual CourseTestDbo CourseTest { get; set; }
        public virtual Guid? CourseTestId { get; set; }
        public virtual ICollection<CourseLessonItemDbo> CourseItem { get; set; }
        public virtual ICollection<CourseLessonTranslationDbo> CourseLessonTranslations { get; set; }
    }
}
