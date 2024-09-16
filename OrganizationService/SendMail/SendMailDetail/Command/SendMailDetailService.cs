using Core.Base.Command.Detail;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailDetail.Convertor;
using OrganizationService.SendMail.SendMailDetail.Dto;
using Repository.SendEmail;

namespace OrganizationService.SendMail.SendMailDetail.Command
{
    public class SendMailDetailService : BaseDetailCommand<SendEmailDbo, ISendEmailRepository, SendMaiDetailDto, ISendMailDetailConvertor>, ISendMailDetailService
    {
        public SendMailDetailService(ISendEmailRepository repository, ISendMailDetailConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
