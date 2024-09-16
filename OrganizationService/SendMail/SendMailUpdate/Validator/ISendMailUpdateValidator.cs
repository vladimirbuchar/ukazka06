using Core.Base.Validator;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailUpdate.Dto;

namespace OrganizationService.SendMail.SendMailUpdate.Validator
{
    public interface ISendMailUpdateValidator : IBaseUpdateValidator<SendEmailDbo, SendMailUpdateDto>
    {
    }
}