using Model.Edu.Course;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CodeBook
{
    [Table("Cb_CourseStatus")]
    public class CourseStatusDbo : CodeBook
    {
        public virtual IEnumerable<CourseDbo> Courses { get; set; }
    }
}
