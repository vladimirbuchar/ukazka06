using Model.Edu.SendEmail;
using OrganizationService.SendMail.SendMailList.Dto;

namespace OrganizationService.SendMail.SendMailList.Convertor
{
    public class SendMailListConvertor : ISendMailListConvertor
    {
        public Task<List<SendMailListDto>> ConvertToWebModel(List<SendEmailDbo> list, List<string> culture)
        {
            return Task.FromResult(list
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
               .ToList());
        }
    }
}
