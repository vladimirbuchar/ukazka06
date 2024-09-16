using Core.Base.Dto;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Dto
{
    public class BankOfQuestionCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public string? Name { get; set; }
        public bool IsDefault { get; set; } = false;
    }
}
