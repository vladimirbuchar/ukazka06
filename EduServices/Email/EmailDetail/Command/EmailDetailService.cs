using Core.Base.Command.Detail;
using Model.Edu.Email;
using Repository.Email;
using Services.Email.EmailDetail.Command;
using Services.Email.EmailDetail.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SystemServices.Email.EmailDetail.Convertor;

namespace SystemServices.Email.EmailDetail.Command
{
    public class EmailDetailService : BaseDetailCommand<EmailDbo, IEmailRepository, EmailDetailDto, IEmailDetailConvertor>, IEmailDetailService
    {
        public EmailDetailService(IEmailRepository repository, IEmailDetailConvertor convertor) : base(repository, convertor)
        {
        }
        public override async Task<EmailDetailDto> Execute(Expression<Func<EmailDbo, bool>> predicate, List<string> culture, Dictionary<string, object> replace = null)
        {
            EmailDetailDto email = await base.Execute(predicate, culture, replace);
            string emailBodyHtml = email.EmailBodyHtml;
            string emailBodyPlainText = email.EmailBodyPlainText;
            string subject = email.Subject;
            foreach (KeyValuePair<string, object> item in replace)
            {
                emailBodyHtml = emailBodyHtml.Replace("{" + item.Key + "}", item.Value.ToString());
                emailBodyPlainText = emailBodyPlainText.Replace("{" + item.Key + "}", item.Value.ToString());
                subject = subject.Replace("{" + item.Key + "}", item.Value.ToString());
            }
            email.Subject = subject;
            email.EmailBodyPlainText = emailBodyPlainText;
            email.EmailBodyHtml = emailBodyHtml;
            return email;
        }
    }
}
