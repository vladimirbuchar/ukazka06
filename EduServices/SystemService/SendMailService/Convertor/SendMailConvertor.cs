using System.Collections.Generic;
using System.Linq;
using Model.Edu.SendEmail;
using Services.SystemService.SendMailService.Dto;

namespace Services.SystemService.SendMailService.Convertor
{
    public class SendMailConvertor : ISendMailConvertor
    {
        public List<SendMailListDto> ConvertToWebModel(List<SendEmailDbo> sendEmail)
        {
            return sendEmail
                .Select(x => new SendMailListDto()
                {
                    Id = x.Id,
                    EmailFrom = x.EmailFrom,
                    EmailTo = x.EmailTo,
                    EmailFromName = x.EmailFromName,
                    EmailToName = x.EmailToName,
                    ErrorMessage = x.ErrorMessage,
                    IsError = x.IsError,
                    IsHtml = x.IsHtml,
                    IsSended = x.IsSended,
                    Reply = x.Reply,
                    Subject = x.Subject
                })
                .ToList();
        }

        public SendMaiDetailDto ConvertToWebModel(SendEmailDbo sendEmail)
        {
            return new SendMaiDetailDto()
            {
                Id = sendEmail.Id,
                EmailFrom = sendEmail.EmailFrom,
                EmailTo = sendEmail.EmailTo,
                EmailFromName = sendEmail.EmailFromName,
                EmailToName = sendEmail.EmailToName,
                ErrorMessage = sendEmail.ErrorMessage,
                IsError = sendEmail.IsError,
                IsHtml = sendEmail.IsHtml,
                IsSended = sendEmail.IsSended,
                Reply = sendEmail.Reply,
                Subject = sendEmail.Subject,
                Body = sendEmail.Body,
                Attagments = sendEmail.SendEmailAttachments.Select(y => new SendMaiDetailAttachmentsDto() { Attachment = y.Attachment }).ToList(),
                PlainTextBody = sendEmail.PlainTextBody
            };
        }
    }
}
