using System.Collections.Generic;
using Core.Base.Dto;

namespace Services.CourseStudy.Dto
{
    public class CourseLessonQuestionStudyDto : ListDto
    {
        public CourseLessonQuestionStudyDto()
        {
            Answers = [];
        }

        public string Question { get; set; }
        public string AnswerMode { get; set; }
        public HashSet<CourseLessonAnswerDto> Answers { get; set; }
        public string QuestionMode { get; set; }
        public string FilePath { get; set; }
    }
}
