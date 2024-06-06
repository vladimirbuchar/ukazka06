using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.Answer;
using Model.Tables.Edu.StudentTestSummary;
using Model.Tables.Edu.TestQuestion;

namespace Model.Tables.Edu.TestUserAnswer
{
    [Table("Edu_TestUserAnswer")]
    public class TestUserAnswerDbo : TableModel
    {
        public virtual StudentTestSummaryDbo StudentTestSummary { get; set; }
        public virtual Guid StudentTestSummaryId { get; set; }
        public virtual QuestionDbo TestQuestion { get; set; }
        public virtual Guid TestQuestionId { get; set; }
        public virtual AnswerDbo TestQuestionAnswer { get; set; }
        public virtual Guid TestQuestionAnswerId { get; set; }
    }
}
