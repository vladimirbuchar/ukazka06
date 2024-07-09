using System;
using System.Collections.Generic;
using Core.Base.Dto;

namespace Services.Test.Dto
{
    public class CourseTestDetailDto : DetailDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRandomGenerateQuestion { get; set; }
        public int QuestionCountInTest { get; set; }
        public int TimeLimit { get; set; }
        public int DesiredSuccess { get; set; }
        public List<Guid> BankOfQuestion { get; set; }
        public int MaxRepetition { get; set; }
    }
}
