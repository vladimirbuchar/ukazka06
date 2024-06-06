﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.Answer
{
    [Table("Edu_AnswerFileRepository")]
    public class AnswerFileRepositoryDbo : FileRepositoryModel
    {
        public AnswerDbo Answer { get; set; }
        public Guid AnswerId { get; set; }
    }
}
