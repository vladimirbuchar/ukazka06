using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.CourseLessonItem;

namespace Model.CodeBook
{
    [Table("Cb_CourseLessonItemTemplate")]
    public class CourseLessonItemTemplateDbo : CodeBook
    {
        public virtual IEnumerable<CourseLessonItemDbo> CourseLessonItems { get; set; }
    }
}
