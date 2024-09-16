using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailDetail.Dto;

namespace OrganizationService.SendMail.SendMailDetail.Convertor
{
    public class SendMailDetailConvertor : ISendMailDetailConvertor
    {
        public Task<SendMaiDetailDto> ConvertToWebModel(SendEmailDbo detail, List<string> culture)
        {
            return Task.FromResult(new SendMaiDetailDto()
            {
                Id = detail.Id,
                EmailFrom = detail.EmailFrom,
                EmailTo = detail.EmailTo,
                EmailFromName = detail.EmailFromName,
                EmailToName = detail.EmailToName,
                ErrorMessage = detail.ErrorMessage,
                IsError = detail.IsError,
                IsHtml = detail.IsHtml,
                IsSended = detail.IsSended,
                Reply = detail.Reply,
                Subject = detail.Subject,
                Body = detail.Body,
                Attagments = detail.SendEmailAttachments.Select(y => new SendMaiDetailAttachmentsDto() { Attachment = y.Attachment }).ToList(),
                PlainTextBody = detail.PlainTextBody
            });
        }
    }
}
