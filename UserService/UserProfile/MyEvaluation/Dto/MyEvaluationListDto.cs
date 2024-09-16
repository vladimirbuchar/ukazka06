using Core.Base.Dto;

namespace UserService.UserProfile.MyEvaluation.Dto
{
    public class MyEvaluationListDto : ListDto
    {
        public DateTime Date { get; set; }
        public string Evaluation { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public string Email { get; set; } = string.Empty;
        public Guid StudentId { get; set; }
    }
}
