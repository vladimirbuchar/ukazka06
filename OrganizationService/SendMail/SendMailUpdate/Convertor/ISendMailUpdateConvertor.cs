using Core.Base.Convertor;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailUpdate.Dto;

namespace OrganizationService.SendMail.SendMailUpdate.Convertor
{
    public interface ISendMailUpdateConvertor : IBaseUpdateConvertor<SendEmailDbo, SendMailUpdateDto>
    {
    }
}