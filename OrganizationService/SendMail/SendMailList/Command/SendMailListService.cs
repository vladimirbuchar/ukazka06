using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailList.Convertor;
using OrganizationService.SendMail.SendMailList.Dto;
using Repository.SendEmail;

namespace OrganizationService.SendMail.SendMailList.Command
{
    public class SendMailListService : BaseListCommand<SendEmailDbo, ISendEmailRepository, SendMailListDto, ISendMailListConvertor, RequestFilter>, ISendMailListService
    {
        public SendMailListService(ISendEmailRepository repository, ISendMailListConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
