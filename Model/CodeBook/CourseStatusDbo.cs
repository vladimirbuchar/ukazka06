using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.Course;

namespace Model.CodeBook
{
    [Table("Cb_CourseStatus")]
    public class CourseStatusDbo : CodeBook
    {
        public virtual IEnumerable<CourseDbo> Courses { get; set; }
    }
}
