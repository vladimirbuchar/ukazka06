using System;
using Core.Base.Dto;

namespace EduServices.CourseStudy.Dto
{
    public class ShowTestResultAnswerDto : ListDto
    {
        public Guid TestQuestionAnswerId { get; set; }
        public bool IsTrueAnswer { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public bool UserAnswer { get; set; }
        public bool UserAnswerIsCorrect { get; set; }
        public string FilePath { get; set; }
        public string UserTestImageAnswer { get; set; }
    }
}
