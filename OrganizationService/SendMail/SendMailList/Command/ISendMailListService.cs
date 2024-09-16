using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailList.Dto;

namespace OrganizationService.SendMail.SendMailList.Command
{
    public interface ISendMailListService : IBaseListCommand<SendEmailDbo, SendMailListDto, RequestFilter>
    {
    }
}