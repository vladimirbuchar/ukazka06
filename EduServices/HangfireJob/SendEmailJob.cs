using System;
using System.Collections.Generic;
using System.Linq;
using Core.Base.HangfireJob;
using Core.DataTypes;
using Integration.MailKitIntegration;
using Microsoft.Extensions.DependencyInjection;
using Model.Edu.OrganizationSetting;
using Model.Edu.SendEmail;
using Repository.OrganizationSettingRepository;
using Repository.SendEmailRepository;

namespace Services.HangfireJob
{
    public class SendEmailJob(IServiceScopeFactory serviceScopeFactory) : Hangfire(serviceScopeFactory)
    {
        public override void Execute()
        {
            ISendEmailRepository _repository = _scope.ServiceProvider.GetRequiredService<ISendEmailRepository>();
            IOrganizationSettingRepository _organizationSettingRepository = _scope.ServiceProvider.GetRequiredService<IOrganizationSettingRepository>();
            IMailKitIntegration _mailKitIntegration = _scope.ServiceProvider.GetRequiredService<IMailKitIntegration>();
            HashSet<SendEmailDbo> sendEmails = _repository.GetEntities(false, x => x.IsSended == false && x.IsError == false);
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
                        Email email =
                            new()
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
                        _mailKitIntegration.SendEmail(email);
                    }
                    sendEmail.IsSended = true;
                    sendEmail.IsError = false;
                }
                catch (Exception ex)
                {
                    sendEmail.IsSended = false;
                    sendEmail.IsError = true;
                    sendEmail.ErrorMessage = ex.Message;
                }
                finally
                {
                    _ = _repository.UpdateEntity(sendEmail, Guid.Empty);
                }
            }
        }
    }
}
