using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.CourseLesson
{
    [Table("Edu_CourseLessonFileRepository")]
    public class CourseLessonFileRepositoryDbo : FileRepositoryModel
    {
        public CourseLessonDbo CourseLesson { get; set; }
        public Guid CourseLessonId { get; set; }
    }
}
