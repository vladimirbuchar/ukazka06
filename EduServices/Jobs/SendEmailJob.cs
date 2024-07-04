using Core.DataTypes;
using EduRepository.EmailRepository;
using EduRepository.OrganizationSettingRepository;
using Integration.MailKitIntegration;
using Microsoft.Extensions.DependencyInjection;
using Model.Tables.Edu.OrganizationSetting;
using Model.Tables.Edu.SendEmail;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Jobs
{
    public class SendEmailJob(IServiceScopeFactory serviceScopeFactory)
    {
        private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;
        public void Execute()
        {
            using IServiceScope scope = _serviceScopeFactory.CreateScope();
            IEmailRepository _repository = scope.ServiceProvider.GetRequiredService<IEmailRepository>();
            IOrganizationSettingRepository _organizationSettingRepository = scope.ServiceProvider.GetRequiredService<IOrganizationSettingRepository>();
            IMailKitIntegration _mailKitIntegration = scope.ServiceProvider.GetRequiredService<IMailKitIntegration>();
            HashSet<SendEmailDbo> sendEmails = _repository.GetEntities(false, x => x.IsSended == false);
            foreach (SendEmailDbo sendEmail in sendEmails)
            {
                try
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
                                Attachment = sendEmail?.SendEmailAttachments?.Select(x => x.Attachment).ToList(),
                                From = new EmailAddress() { Email = sendEmail.EmailFrom, Name = sendEmail.EmailFromName },
                                Reply = sendEmail.Reply
                            },
                            getOrganizationSetting.SmtpServerUrl,
                            getOrganizationSetting.SmtpServerPort,
                            getOrganizationSetting.SmtpServerUserName,
                            getOrganizationSetting.SmtpServerPassword
                        );
                    }
                    else
                    {
                        Email email = new()
                        {
                            EmailBody = new EmailBody()
                            {
                                HtmlBody = sendEmail.Body,
                                IsHtml = true,
                                PlainTextBody = sendEmail.PlainTextBody
                            },
                            To = new EmailAddress() { Email = sendEmail.EmailTo, Name = sendEmail.EmailToName },
                            Subject = sendEmail.Subject,
                            Attachment = sendEmail.SendEmailAttachments?.Select(x => x.Attachment).ToList(),
                            Reply = sendEmail.Reply
                        };
                        _mailKitIntegration.SendEmail(
                          email
                        );
                    }
                    sendEmail.IsSended = true;
                    _ = _repository.UpdateEntity(sendEmail, Guid.Empty);
                }
                catch (Exception)
                {
                    //  logger.LogError("Email", ex);
                }
            }

        }
    }
}