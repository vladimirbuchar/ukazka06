using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.CourseLessonItem
{
    [Table("Edu_CourseLessonItemFileRepository")]
    public class CourseLessonItemFileRepositoryDbo : FileRepositoryModel
    {
        public CourseLessonItemDbo CourseLessonItem { get; set; }
        public Guid CourseLessonItemId { get; set; }
    }
}
