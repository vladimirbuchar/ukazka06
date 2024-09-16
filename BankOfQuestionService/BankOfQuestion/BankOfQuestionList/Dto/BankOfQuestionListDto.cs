using Core.Base.Dto;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Dto
{
    public class BankOfQuestionListDto : ListDto
    {
        public string? Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
