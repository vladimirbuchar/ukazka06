using Core.Base.Validator;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailUpdate.Dto;
using Repository.SendEmail;

namespace OrganizationService.SendMail.SendMailUpdate.Validator
{
    public class SendMailUpdateValidator(ISendEmailRepository repository) : BaseUpdateValidator<SendEmailDbo, ISendEmailRepository, SendMailUpdateDto>(repository), ISendMailUpdateValidator
    {
    }
}
