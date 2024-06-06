using Core.Base.Dto;
using System;

namespace EduServices.BankOfQuestion.Dto
{
    public class BankOfQuestionCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
    }
}
