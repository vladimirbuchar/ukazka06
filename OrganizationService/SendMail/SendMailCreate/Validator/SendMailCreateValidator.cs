using Core.Base.Validator;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailCreate.Dto;
using Repository.SendEmail;

namespace OrganizationService.SendMail.SendMailCreate.Validator
{
    public class SendMailCreateValidator : BaseCreateValidator<SendEmailDbo, ISendEmailRepository, SendMailCreateDto>, ISendMailCreateValidator
    {
        public SendMailCreateValidator(ISendEmailRepository repository) : base(repository)
        {
        }
    }
}
