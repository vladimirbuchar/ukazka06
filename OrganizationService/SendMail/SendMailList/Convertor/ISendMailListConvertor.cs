using Core.Base.Convertor;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailList.Dto;

namespace OrganizationService.SendMail.SendMailList.Convertor
{
    public interface ISendMailListConvertor : IBaseListConvertor<SendEmailDbo, SendMailListDto>
    {
    }
}