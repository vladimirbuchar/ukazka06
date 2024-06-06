using System;

namespace EduServices.Answer.Dto
{
    public class AnswerCreate : Answer
    {
        public Guid QuestionId { get; set; }

    }
}
