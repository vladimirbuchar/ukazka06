using Core.Base.Dto;
using EduServices.CourseLesson.Dto;
using System;
using System.Collections.Generic;

namespace EduServices.Test.Dto
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
