using Core.Base.Dto;

namespace EduServices.BankOfQuestion.Dto
{
    public class BankOfQuestionDetailDto : DetailDto
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
