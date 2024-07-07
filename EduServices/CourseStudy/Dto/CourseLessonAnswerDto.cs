using Core.Base.Dto;

namespace Services.CourseStudy.Dto
{
    public class CourseLessonAnswerDto : ListDto
    {
        public string Answer { get; set; }
        public string FilePath { get; set; }
    }
}
