using Core.Base.Dto;

namespace CourseMaterialService.CourseLesson.CourseLessonDetail.Dto
{
    public class CourseLessonDetailDto : DetailDto
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public bool? IsRandomGenerateQuestion { get; set; }
        public int? QuestionCountInTest { get; set; }
        public int? TimeLimit { get; set; }
        public int? DesiredSuccess { get; set; }
        public required List<Guid> BankOfQuestion { get; set; }
        public int? MaxRepetition { get; set; }
        public Guid? TestId { get; set; }
    }
}
