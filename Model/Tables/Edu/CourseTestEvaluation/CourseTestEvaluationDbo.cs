using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.CourseTest;

namespace Model.Tables.Edu.CourseTestEvaluation
{
    [Table("Edu_CourseTestEvaluation")]
    public class CourseTestEvaluationDbo : TableModel
    {
        public virtual int? PointFrom { get; set; }
        public virtual int? PointTo { get; set; }
        public string Evaluation { get; set; }
        public virtual CourseTestDbo CourseTest { get; set; }
        public virtual Guid CourseTestId { get; set; }
    }
}
