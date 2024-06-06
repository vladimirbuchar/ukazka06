using Core.Base.Dto;

namespace EduServices.BankOfQuestion.Dto
{
    public class BankOfQuestionListDto : ListDto
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
