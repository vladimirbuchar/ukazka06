using Core.Base.Dto;
using System.Collections.Generic;

namespace Services.CourseStudy.Dto
{
    public class ShowStudentAnswerDto : ListDto
    {
        public ShowStudentAnswerDto()
        {
            Answer = [];
        }

        public string Question { get; set; }
        public int Score { get; set; }
        public bool IsTrue { get; set; }
        public string AnswerMode { get; set; }
        public HashSet<StudentAswerResult> Answer { get; set; }
    }
}
