using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.Course;

namespace Model.Tables.CodeBook
{
    [Table("Cb_CourseType")]
    public class CourseTypeDbo : CodeBook
    {
        public virtual IEnumerable<CourseDbo> Courses { get; set; }
    }
}
