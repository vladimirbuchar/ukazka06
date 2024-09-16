using Core.Base.Convertor;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailDetail.Dto;

namespace OrganizationService.SendMail.SendMailDetail.Convertor
{
    public interface ISendMailDetailConvertor : IBaseDetailConvertor<SendEmailDbo, SendMaiDetailDto>
    {
    }
}