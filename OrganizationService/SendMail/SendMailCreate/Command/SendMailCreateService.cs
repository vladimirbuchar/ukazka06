using Core.Base.Command.Create;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailCreate.Convertor;
using OrganizationService.SendMail.SendMailCreate.Dto;
using OrganizationService.SendMail.SendMailCreate.Validator;
using Repository.SendEmail;

namespace OrganizationService.SendMail.SendMailCreate.Command
{
    public class SendMailCreateService : BaseCreateCommand<SendEmailDbo, ISendEmailRepository, SendMailCreateDto, ISendMailCreateConvertor, ISendMailCreateValidator>, ISendMailCreateService
    {
        public SendMailCreateService(ISendEmailRepository repository, ISendMailCreateConvertor convertor, ISendMailCreateValidator validator) : base(repository, convertor, validator)
        {
        }

    }
}
