using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.BankOfQuestions
{
    [Table("Edu_BankOfQuestionTranslation")]
    public class BankOfQuestionsTranslationDbo : TranslationTableModel
    {
        [Column("Name")]
        public virtual string Name { get; set; }
        public virtual BankOfQuestionDbo BankOfQuestion { get; set; }
        public virtual Guid BankOfQuestionId { get; set; }
    }
}
