using Core.Base.Dto;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Dto
{
    public class BankOfQuestionDetailDto : DetailDto
    {
        public string? Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
