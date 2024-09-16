using Core.Base.Command.Create;
using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailCreate.Dto;

namespace OrganizationService.SendMail.SendMailCreate.Command
{
    public interface ISendMailCreateService : IBaseCreateCommand<SendEmailDbo, SendMailCreateDto>
    {
    }
}