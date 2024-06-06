using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.CourseLessonItem;

namespace Model.Tables.CodeBook
{
    [Table("Cb_CourseLessonItemTemplate")]
    public class CourseLessonItemTemplateDbo : CodeBook
    {
        public virtual IEnumerable<CourseLessonItemDbo> CourseLessonItems { get; set; }
    }
}
