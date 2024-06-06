using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.BankOfQuestions;
using Model.Tables.Edu.CourseTest;

namespace Model.Tables.Link
{
    [Table("Link_TestBankOfQuestion")]
    public class CourseTestBankOfQuestionDbo : TableModel
    {
        public virtual BankOfQuestionDbo BankOfQuestion { get; set; }
        public virtual Guid BankOfQuestionId { get; set; }
        public virtual CourseTestDbo CourseTest { get; set; }
        public virtual Guid CourseTestId { get; set; }
    }
}
