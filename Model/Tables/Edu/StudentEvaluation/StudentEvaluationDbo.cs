using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.CourseTerm;
using Model.Tables.Link;

namespace Model.Tables.Edu.StudentEvaluation
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
