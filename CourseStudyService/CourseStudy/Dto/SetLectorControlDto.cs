using Core.Base.Dto;

namespace CourseStudyService.CourseStudy.Dto
{
    public class SetLectorControlDto : UpdateDto
    {
        public bool IsTrue { get; set; }
        public Guid QuestionId { get; set; }

        public int Score { get; set; }
        public Guid StudentTestResultId { get; set; }
    }
}
