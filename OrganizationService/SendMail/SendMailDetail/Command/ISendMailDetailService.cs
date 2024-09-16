using Core.Base.Command.Detail;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailDetail.Dto;

namespace OrganizationService.SendMail.SendMailDetail.Command
{
    public interface ISendMailDetailService : IBaseDetailCommand<SendEmailDbo, SendMaiDetailDto>
    {
    }
}