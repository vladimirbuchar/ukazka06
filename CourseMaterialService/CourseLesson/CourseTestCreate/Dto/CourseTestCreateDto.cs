using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace CourseMaterialService.CourseLesson.CourseTestCreate.Dto
{
    public class CourseTestCreateDto : CreateDto
    {
        public bool IsRandomGenerateQuestion { get; set; }
        public int QuestionCountInTest { get; set; }
        public int TimeLimit { get; set; }
        public int DesiredSuccess { get; set; }
        public required List<Guid> BankOfQuestion { get; set; }
        public int MaxRepetition { get; set; }

        [JsonIgnore]
        public Guid CourseLessonId { get; set; }
    }
}
