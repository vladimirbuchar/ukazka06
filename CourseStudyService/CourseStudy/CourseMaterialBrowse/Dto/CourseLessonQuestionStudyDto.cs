using Core.Base.Dto;
using Services.CourseStudy.CourseMaterialBrowse.Dto;

namespace CourseStudyService.CourseStudy.CourseMaterialBrowse.Dto
{
    public class CourseLessonQuestionStudyDto : ListDto
    {
        public CourseLessonQuestionStudyDto()
        {
            Answers = [];
        }

        public string Question { get; set; }
        public string AnswerMode { get; set; }
        public List<CourseLessonAnswerDto> Answers { get; set; }
        public string QuestionMode { get; set; }
        public string FilePath { get; set; }
    }
}
