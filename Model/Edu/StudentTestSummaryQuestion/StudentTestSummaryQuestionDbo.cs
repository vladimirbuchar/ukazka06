using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.CodeBook;
using Model.Edu.Question;
using Model.Edu.StudentTestSummary;
using Model.Edu.StudentTestSummaryAnswer;

namespace Model.Edu.StudentTestSummaryQuestion
{
    [Table("Edu_StudentTestSummaryQuestion")]
    public class StudentTestSummaryQuestionDbo : TableModel
    {
        [Column("Question")]
        public virtual string Question { get; set; }

        [Column("Score")]
        public virtual int Score { get; set; }

        [Column("IsTrue")]
        public virtual bool IsTrue { get; set; }

        [Column("IsAutomaticEvaluate")]
        public virtual bool IsAutomaticEvaluate { get; set; }

        [Column("Position")]
        public virtual int Position { get; set; }

        [Column("FilePath")]
        public virtual string FilePath { get; set; }
        public virtual AnswerModeDbo AnswerMode { get; set; }
        public virtual Guid AnswerModeId { get; set; }
        public virtual QuestionDbo TestQuestion { get; set; }
        public virtual Guid TestQuestionId { get; set; }
        public virtual QuestionModeDbo QuestionMode { get; set; }
        public virtual Guid QuestionModeId { get; set; }
        public virtual StudentTestSummaryDbo StudentTestSummary { get; set; }
        public virtual Guid StudentTestSummaryId { get; set; }
        public virtual ICollection<StudentTestSummaryAnswerDbo> StudentTestSummaryAnswers { get; set; }
    }
}
