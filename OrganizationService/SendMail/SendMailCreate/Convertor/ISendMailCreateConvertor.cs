using Core.Base.Convertor;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailCreate.Dto;

namespace OrganizationService.SendMail.SendMailCreate.Convertor
{
    public interface ISendMailCreateConvertor : IBaseCreateConvertor<SendEmailDbo, SendMailCreateDto>
    {
    }
}