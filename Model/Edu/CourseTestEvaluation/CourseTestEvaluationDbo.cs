using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.CourseTest;

namespace Model.Edu.CourseTestEvaluation
{
    [Table("Edu_CourseTestEvaluation")]
    public class CourseTestEvaluationDbo : TableModel
    {
        [Column("PointFrom")]
        public virtual int? PointFrom { get; set; }

        [Column("PointTo")]
        public virtual int? PointTo { get; set; }

        [Column("Evaluation")]
        public string Evaluation { get; set; }
        public virtual CourseTestDbo CourseTest { get; set; }
        public virtual Guid CourseTestId { get; set; }
    }
}
