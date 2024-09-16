using Core.Base.Command.Update;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailUpdate.Convertor;
using OrganizationService.SendMail.SendMailUpdate.Dto;
using OrganizationService.SendMail.SendMailUpdate.Validator;
using Repository.SendEmail;

namespace OrganizationService.SendMail.SendMailUpdate.Command
{
    public class SendMailUpdateService : BaseUpdateCommand<SendEmailDbo, ISendEmailRepository, SendMailUpdateDto, ISendMailUpdateConvertor, ISendMailUpdateValidator>, ISendMailUpdateService
    {
        public SendMailUpdateService(ISendEmailRepository repository, ISendMailUpdateConvertor convertor, ISendMailUpdateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
