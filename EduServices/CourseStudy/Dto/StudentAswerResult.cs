using Core.Base.Dto;
using System;

namespace Services.CourseStudy.Dto
{
    public class StudentAswerResult : ListDto
    {
        public bool UserAnswer { get; set; }
        public string Text { get; set; }
        public Guid AnswerId { get; set; }
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
    }
}
