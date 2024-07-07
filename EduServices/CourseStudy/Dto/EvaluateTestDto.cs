using System;
using System.Collections.Generic;
using Core.Base.Dto;

namespace Services.CourseStudy.Dto
{
    public class EvaluateTestDto : ListDto
    {
        public EvaluateTestDto()
        {
            EvaluateQuestions = [];
        }

        public Guid? UserTestSummaryId { get; set; }
        public List<EvaluateQuestionDto> EvaluateQuestions { get; set; }
        public Guid CourseLessonId { get; set; }
        public bool IsAutomatic { get; set; }
        public bool IsSucess { get; set; }
        public double Score { get; set; }
    }
}
