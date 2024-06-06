using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Answer;
using Model.Tables.Edu.BankOfQuestions;
using Model.Tables.Edu.StudentTestSummaryQuestion;
using Model.Tables.Edu.TestUserAnswer;

namespace Model.Tables.Edu.TestQuestion
{
    [Table("Edu_TestQuestion")]
    public class QuestionDbo : TableModel
    {
        [Column("Position")]
        public int Position { get; set; }
        public virtual AnswerModeDbo AnswerMode { get; set; }
        public virtual Guid AnswerModeId { get; set; }
        public virtual QuestionModeDbo QuestionMode { get; set; }
        public virtual Guid QuestionModeId { get; set; }
        public virtual BankOfQuestionDbo BankOfQuestion { get; set; }
        public virtual Guid BankOfQuestionId { get; set; }
        public virtual ICollection<QuestionTranslationDbo> TestQuestionTranslation { get; set; }
        public virtual ICollection<AnswerDbo> TestQuestionAnswer { get; set; }
        public virtual ICollection<StudentTestSummaryQuestionDbo> StudentTestSummaryQuestions { get; set; }
        public virtual ICollection<TestUserAnswerDbo> TestUserAnswers { get; set; }
        public virtual ICollection<QuestionFileRepositoryDbo> QuestionFileRepositories { get; set; }

        [NotMapped]
        public virtual bool IsAutomatic { get; set; }
    }
}
