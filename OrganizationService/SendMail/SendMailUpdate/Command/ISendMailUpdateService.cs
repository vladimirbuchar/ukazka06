using Core.Base.Command.Update;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailUpdate.Dto;

namespace OrganizationService.SendMail.SendMailUpdate.Command
{
    public interface ISendMailUpdateService : IBaseUpdateCommand<SendEmailDbo, SendMailUpdateDto>
    {
    }
}