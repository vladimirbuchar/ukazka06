using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailUpdate.Dto;

namespace OrganizationService.SendMail.SendMailUpdate.Convertor
{
    public class SendMailUpdateConvertor : ISendMailUpdateConvertor
    {
        public Task<SendEmailDbo> ConvertToBussinessEntity(SendMailUpdateDto update, SendEmailDbo entity, string culture)
        {
            entity.IsSended = update.IsSended;
            return Task.FromResult(entity);
        }
    }
}
