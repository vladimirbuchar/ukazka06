using Model.Edu.CourseLessonItem;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CodeBook
{
    [Table("Cb_CourseLessonItemTemplate")]
    public class CourseLessonItemTemplateDbo : CodeBook
    {
        public virtual IEnumerable<CourseLessonItemDbo> CourseLessonItems { get; set; }
    }
}
