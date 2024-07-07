using Model.Edu.Answer;
using Model.Edu.StudentTestSummaryQuestion;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.StudentTestSummaryAnswer
{
    [Table("Edu_StudentTestSummaryAnswer")]
    public class StudentTestSummaryAnswerDbo : TableModel
    {
        [Column("Answer")]
        public virtual string Answer { get; set; }

        [Column("IsTrueAnswer")]
        public virtual bool IsTrueAnswer { get; set; }

        [Column("UserTestAnswer")]
        public virtual string UserTestAnswer { get; set; }

        [Column("UserAnswer")]
        public virtual bool UserAnswer { get; set; }

        [Column("Position")]
        public virtual int Position { get; set; }

        [Column("UserAnswerIsCorrect")]
        public virtual bool UserAnswerIsCorrect { get; set; }

        [Column("FilePath")]
        public virtual string FilePath { get; set; }

        [Column("UserTestImageAnswer")]
        public virtual Guid UserTestImageAnswer { get; set; }
        public virtual AnswerDbo TestQuestionAnswer { get; set; }
        public virtual Guid TestQuestionAnswerId { get; set; }
        public virtual StudentTestSummaryQuestionDbo StudentTestSummaryQuestion { get; set; }
        public virtual Guid StudentTestSummaryQuestionId { get; set; }
    }
}
