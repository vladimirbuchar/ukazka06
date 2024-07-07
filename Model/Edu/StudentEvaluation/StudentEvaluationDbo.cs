using Model.Edu.CourseTerm;
using Model.Link;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.StudentEvaluation
{
    [Table("Edu_StudentEvaluation")]
    public class StudentEvaluationDbo : TableModel
    {
        [Column("Date")]
        public virtual DateTime Date { get; set; }

        [Column("Evaluation")]
        public virtual string Evaluation { get; set; }
        public virtual CourseTermDbo CourseTerm { get; set; }
        public virtual Guid CourseTermId { get; set; }
        public virtual CourseStudentDbo CourseStudent { get; set; }
        public virtual Guid CourseStudentId { get; set; }
    }
}
