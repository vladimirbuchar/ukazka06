using Core.Base.Dto;

namespace EduServices.CourseStudy.Dto
{
    public class CourseLessonAnswerDto : ListDto
    {
        public string Answer { get; set; }
        public string FilePath { get; set; }
    }
}
