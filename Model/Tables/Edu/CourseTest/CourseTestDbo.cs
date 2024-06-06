using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.CourseLesson;
using Model.Tables.Edu.CourseTestEvaluation;
using Model.Tables.Link;

namespace Model.Tables.Edu.CourseTest
{
    [Table("Edu_CourseTest")]
    public class CourseTestDbo : TableModel
    {
        [Column("IsRandomGenerateQuestion")]
        public virtual bool IsRandomGenerateQuestion { get; set; }

        [Column("QuestionCountInTest")]
        public virtual int QuestionCountInTest { get; set; }

        [Column("TimeLimit")]
        public virtual int TimeLimit { get; set; }

        [Column("DesiredSuccess")]
        public virtual int DesiredSuccess { get; set; }

        [Column("MaxRepetition")]
        public virtual int MaxRepetition { get; set; }
        public virtual IEnumerable<CourseTestEvaluationDbo> CourseTestEvaluations { get; set; }
        public virtual IEnumerable<CourseTestBankOfQuestionDbo> CourseTestBankOfQuestions { get; set; }

        public virtual CourseLessonDbo CourseLesson { get; set; }
        public virtual Guid CourseLessonId { get; set; }
    }
}
