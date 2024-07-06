using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.Question
{
    [Table("Edu_QuestionFileRepository")]
    public class QuestionFileRepositoryDbo : FileRepositoryModel
    {
        public QuestionDbo Question { get; set; }
        public Guid QuestionId { get; set; }
    }
}
