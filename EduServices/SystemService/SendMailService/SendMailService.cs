﻿using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.SendEmail;
using Model.Edu.SendEmailAttachment;
using Repository.SendEmailRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.SystemService.SendMailService
{
    public class SendMailService(
        ISendEmailRepository emailRepository,
        ICodeBookRepository<EduEmailDbo> codeBookRepository
    ) : BaseService<ISendEmailRepository, SendEmailDbo>(emailRepository), ISendMailService
    {
        private readonly ICodeBookRepository<EduEmailDbo> _email = codeBookRepository;

        public void AddEmailToQueue(string subject, string html, List<string> attachment, EmailAddress emailAddressTo, Guid organizationId, string reply)
        {
            _ = _repository.CreateEntity(
                new SendEmailDbo()
                {
                    Body = html,
                    Subject = subject,
                    SendEmailAttachments = attachment.Select(x => new SendEmailAttachmentDbo() { Attachment = x }).ToList()
                },
                Guid.Empty
            );
        }

        public void AddEmailToQueue(string emailIdentificator, string culture, EmailAddress emailAddressTo, Dictionary<string, string> replaceData, Guid? organizationId = null, string reply = "")
        {
            EduEmailDbo eduEmail = _email.GetEntity(false, x => x.SystemIdentificator == string.Format("{0}_{1}", emailIdentificator, culture));
            if (eduEmail == null)
            {
                culture = "en";
                eduEmail = _email.GetEntity(false, x => x.SystemIdentificator == string.Format("{0}_{1}", emailIdentificator, culture));
            }
            if (eduEmail != null)
            {
                string emailBodyHtml = eduEmail.EmailBodyHtml;
                string emailBodyPlainText = eduEmail.EmailBodyPlainText;
                foreach (KeyValuePair<string, string> item in replaceData)
                {
                    emailBodyHtml = emailBodyHtml.Replace("{" + item.Key + "}", item.Value);
                    emailBodyPlainText = emailBodyPlainText.Replace("{" + item.Key + "}", item.Value);
                }
                _ = _repository.CreateEntity(
                    new SendEmailDbo()
                    {
                        Body = emailBodyHtml,
                        PlainTextBody = emailBodyPlainText,
                        Subject = eduEmail.Subject,
                        EmailFrom = eduEmail.From,
                        IsHtml = true,
                        IsSended = false,
                        OrganizationId = organizationId,
                        EmailTo = emailAddressTo.Email,
                        EmailToName = emailAddressTo.Name,
                        Reply = reply
                    },
                    Guid.Empty
                );
            }
        }
    }
}
