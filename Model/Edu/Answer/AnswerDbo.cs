using Model.Edu.Question;
using Model.Edu.TestUserAnswer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.Answer
{
    [Table("Edu_TestQuestionAnswer")]
    public class AnswerDbo : TableModel
    {
        [Column("IsTrueAnswer")]
        public virtual bool IsTrueAnswer { get; set; }

        [Column("Position")]
        public virtual int Position { get; set; }

        [Column("TestQuestionId")]
        public virtual Guid TestQuestionId { get; set; }
        public virtual QuestionDbo TestQuestion { get; set; }
        public virtual ICollection<AnswerFileRepositoryDbo> AnswerFileRepository { get; set; }
        public virtual ICollection<AnswerTanslationDbo> TestQuestionAnswerTranslations { get; set; }
        public virtual ICollection<TestUserAnswerDbo> TestUserAnswers { get; set; }
    }
}
