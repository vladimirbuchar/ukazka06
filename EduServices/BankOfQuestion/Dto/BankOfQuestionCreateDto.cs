using Core.Base.Dto;
using System;

namespace Services.BankOfQuestion.Dto
{
    public class BankOfQuestionCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
    }
}
