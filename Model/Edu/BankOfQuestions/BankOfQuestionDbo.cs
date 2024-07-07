using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.Organization;
using Model.Edu.Question;

namespace Model.Edu.BankOfQuestions
{
    [Table("Edu_BankOfQuestion")]
    public class BankOfQuestionDbo : TableModel
    {
        [Column("IsDefault")]
        public virtual bool IsDefault { get; set; }

        [Column("Position")]
        public virtual int Position { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual Guid OrganizationId { get; set; }
        public virtual ICollection<BankOfQuestionsTranslationDbo> BankOfQuestionsTranslations { get; set; }
        public virtual ICollection<QuestionDbo> TestQuestions { get; set; }
    }
}
