using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.CourseTable
{
    [Table("Edu_CourseTable")]
    public class CourseTableDbo : TableModel
    {

        [NotMapped]
        public string Image { get; set; }

    }
}
