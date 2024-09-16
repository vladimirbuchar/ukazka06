using Model.Edu.SendEmail;
using Model.Edu.SendEmailAttachment;
using OrganizationService.SendMail.SendMailCreate.Dto;

namespace OrganizationService.SendMail.SendMailCreate.Convertor
{
    public class SendMailCreateConvertor : ISendMailCreateConvertor
    {
        public Task<SendEmailDbo> ConvertToBussinessEntity(SendMailCreateDto create, string culture)
        {
            return Task.FromResult(new SendEmailDbo()
            {
                Body = create.Body,
                EmailFrom = create.EmailFrom,
                EmailFromName = create.EmailFromName,
                EmailTo = create.EmailTo,
                EmailToName = create.EmailToName,
                IsHtml = create.IsHtml,
                OrganizationId = create.OrganizationId,
                PlainTextBody = create.PlainTextBody,
                Subject = create.Subject,
                SendEmailAttachments = create.SendEmailAttachments?.Select(x => new SendEmailAttachmentDbo() { Attachment = x }).ToList(),
                Reply = create.Reply
            });
        }
    }
}
