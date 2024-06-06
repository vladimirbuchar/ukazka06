using System;
using System.Collections.Generic;
using Core.Base.Dto;

namespace EduServices.CourseStudy.Dto
{
    public class ShowTestResultQuestionDto : ListDto
    {
        public ShowTestResultQuestionDto()
        {
            UserAnswers = [];
        }

        public Guid TestQuestionId { get; set; }
        public bool IsTrue { get; set; }
        public HashSet<ShowTestResultAnswerDto> UserAnswers { get; set; }
        public string AnswerMode { get; set; }
        public string Question { get; set; }
        public int Score { get; set; }
        public bool IsAutomaticEvaluate { get; set; }
        public Guid QuestionModeId { get; set; }
        public string FilePath { get; set; }
        public string QuestionMode { get; set; }
    }
}
