using System;
using System.Collections.Generic;
using Core.Base.Dto;
using Services.CourseLesson.Dto;

namespace Services.Test.Dto
{
    public class CourseTestUpdateDto : UpdateDto
    {
        public CourseLessonUpdateDto CourseLessonUpdate { get; set; }
        public bool IsRandomGenerateQuestion { get; set; }
        public int QuestionCountInTest { get; set; }
        public int TimeLimit { get; set; }
        public int DesiredSuccess { get; set; }
        public List<Guid> BankOfQuestion { get; set; }
        public int MaxRepetition { get; set; }
    }
}
