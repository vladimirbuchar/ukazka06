using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.TestQuestion
{
    [Table("Edu_QuestionFileRepository")]
    public class QuestionFileRepositoryDbo : FileRepositoryModel
    {
        public QuestionDbo Question { get; set; }
        public Guid QuestionId { get; set; }
    }
}
