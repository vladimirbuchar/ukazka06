using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.Answer
{
    [Table("Edu_TestQuestionAnswerTanslation")]
    public class AnswerTanslationDbo : TranslationTableModel
    {
        [Column("Answer")]
        public virtual string Answer { get; set; }
        public virtual AnswerDbo TestQuestionAnswer { get; set; }
        public virtual Guid TestQuestionAnswerId { get; set; }
    }
}
