using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.TestQuestion
{
    [Table("Edu_TestQuestionTranslation")]
    public class QuestionTranslationDbo : TranslationTableModel
    {
        [Column("Question")]
        public virtual string Question { get; set; }
        public virtual QuestionDbo TestQuestion { get; set; }
        public virtual Guid TestQuestionId { get; set; }
    }
}
