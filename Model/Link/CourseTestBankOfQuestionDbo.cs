using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.BankOfQuestions;
using Model.Edu.CourseTest;

namespace Model.Link
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
