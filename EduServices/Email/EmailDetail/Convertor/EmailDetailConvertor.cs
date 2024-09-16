using Model.Edu.Email;
using Services.Email.EmailDetail.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SystemServices.Email.EmailDetail.Convertor
{
    public class EmailDetailConvertor : IEmailDetailConvertor
    {
        public Task<EmailDetailDto> ConvertToWebModel(EmailDbo detail, List<string> culture)
        {
            return Task.FromResult(new EmailDetailDto()
            {
                EmailBodyHtml = detail.EmailTranslations.FindTranslation(culture).EmailBodyHtml,
                EmailBodyPlainText = detail.EmailTranslations.FindTranslation(culture).EmailBodyPlainText,
                Subject = detail.EmailTranslations.FindTranslation(culture).Subject,
                From = detail.From,
                Id = detail.Id,
                IsHtml = detail.IsHtml
            });
        }
    }
}
