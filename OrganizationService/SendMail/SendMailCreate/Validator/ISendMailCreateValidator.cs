using Core.Base.Validator;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailCreate.Dto;

namespace OrganizationService.SendMail.SendMailCreate.Validator
{
    public interface ISendMailCreateValidator : IBaseCreateValidator<SendEmailDbo, SendMailCreateDto>
    {
    }
}