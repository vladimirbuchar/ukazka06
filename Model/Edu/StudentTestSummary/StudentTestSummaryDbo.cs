using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.Course;
using Model.Edu.CourseTest;
using Model.Edu.StudentTestSummaryQuestion;
using Model.Edu.User;

namespace Model.Edu.StudentTestSummary
{
    [Table("Edu_StudentTestSummary")]
    public class StudentTestSummaryDbo : TableModel
    {
        [Column("StartTime")]
        public virtual DateTime? StartTime { get; set; }

        [Column("Score")]
        public virtual double Score { get; set; }

        [Column("Finish")]
        public virtual DateTime? Finish { get; set; }

        [Column("TestCompleted")]
        public virtual bool IsSucess { get; set; }

        [Column("IsAutomaticEvaluate")]
        public virtual bool IsAutomaticEvaluate { get; set; }
        public virtual CourseTestDbo CourseTest { get; set; }
        public virtual Guid CourseTestId { get; set; }
        public virtual UserDbo User { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual CourseDbo Course { get; set; }
        public virtual Guid CourseId { get; set; }
        public virtual ICollection<StudentTestSummaryQuestionDbo> StudentTestSummaryQuestionDbos { get; set; }
    }
}
