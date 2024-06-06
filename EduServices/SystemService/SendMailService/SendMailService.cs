using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.DataTypes;
using EduRepository.EmailRepository;
using EduRepository.OrganizationSettingRepository;
using Integration.MailKitIntegration;
using Model.Tables.CodeBook;
using Model.Tables.Edu.OrganizationSetting;
using Model.Tables.Edu.SendEmail;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.SystemService.SendMailService
{
    public class SendMailService(
        IOrganizationSettingRepository organizationSettingRepository,
        IMailKitIntegration sendGridIntegration,
        IEmailRepository emailRepository,
        ICodeBookRepository<EduEmailDbo> codeBookRepository
    ) : BaseService<IEmailRepository, SendEmailDbo>(emailRepository), ISendMailService
    {
        private readonly IMailKitIntegration _mailKitIntegration = sendGridIntegration;
        private readonly IOrganizationSettingRepository _organizationSettingRepository = organizationSettingRepository;
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

        public void SendEmail()
        {
            HashSet<SendEmailDbo> sendEmails = _repository.GetEntities(false, x => x.IsSended == false);
            foreach (SendEmailDbo sendEmail in sendEmails)
            {
                OrganizationSettingDbo getOrganizationSetting = _organizationSettingRepository.GetEntity(false, x => x.OrganizationId == sendEmail.OrganizationId);
                if (getOrganizationSetting != null && getOrganizationSetting.UseCustomSmtpServer)
                {
                    _mailKitIntegration.SendEmail(
                        new Email()
                        {
                            EmailBody = new EmailBody()
                            {
                                HtmlBody = sendEmail.Body,
                                IsHtml = true,
                                PlainTextBody = sendEmail.PlainTextBody,
                            },
                            To = new EmailAddress() { Name = sendEmail.EmailToName, Email = sendEmail.EmailTo, },
                            Subject = sendEmail.Subject,
                            Attachment = sendEmail.SendEmailAttachments.Select(x => x.Attachment).ToList(),
                            From = new EmailAddress() { Email = sendEmail.EmailFrom, Name = sendEmail.EmailFromName },
                            Reply = sendEmail.Reply
                        },
                        getOrganizationSetting.SmtpServerUrl,
                        Convert.ToInt32(getOrganizationSetting.SmtpServerPort),
                        getOrganizationSetting.SmtpServerUserName,
                        getOrganizationSetting.SmtpServerPassword
                    );
                }
                else
                {
                    _mailKitIntegration.SendEmail(
                        new Email()
                        {
                            EmailBody = new EmailBody()
                            {
                                HtmlBody = sendEmail.Body,
                                IsHtml = true,
                                PlainTextBody = sendEmail.PlainTextBody
                            },
                            To = new EmailAddress() { Email = sendEmail.EmailTo, Name = sendEmail.EmailToName },
                            Subject = sendEmail.Subject,
                            Attachment = sendEmail.SendEmailAttachments.Select(x => x.Attachment).ToList(),
                            Reply = sendEmail.Reply
                        }
                    );
                }
                sendEmail.IsSended = true;
                _ = _repository.UpdateEntity(sendEmail, Guid.Empty);
            }
        }
    }
}
