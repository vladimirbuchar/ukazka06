using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;

namespace Integration.MailKitIntegration
{
    public class MailKitIntegration(IConfiguration configuration) : IMailKitIntegration
    {
        private readonly IConfiguration _configuration = configuration;

        public void SendEmail(Email mail)
        {
            SendEmail(
                mail,
                _configuration.GetSection(ConfigValue.MAIL).GetSection(ConfigValue.SMTP_SERVER).Value,
                25,
                _configuration.GetSection(ConfigValue.MAIL).GetSection(ConfigValue.EMAIL_USER).Value,
                _configuration.GetSection(ConfigValue.MAIL).GetSection(ConfigValue.EMAIL_PASSWORD).Value
            );
        }

        public void SendEmail(Email mail, string smtpServer, int smtpPort, string smtpUser, string smtpPassword)
        {
            string reply = mail.Reply;
            bool sendEmail = Convert.ToBoolean(_configuration.GetSection(ConfigValue.SEND_EMAIL).Value);
            if (sendEmail)
            {
                MimeMessage message = new();
                MailboxAddress from = new(mail.From.Name, string.IsNullOrWhiteSpace(mail.From.Email) ? ConfigValue.DEFAULT_EMAIL_FROM : mail.From.Email);
                message.From.Add(from);

                MailboxAddress to = new(mail.To.Name, mail.To.Email);
                message.To.Add(to);
                if (!mail.Reply.IsNullOrEmptyWithTrim())
                {
                    message.ReplyTo.Add(new MailboxAddress(mail.Reply, mail.Reply));
                }

                if (!reply.IsNullOrEmptyWithTrim())
                {
                    message.ReplyTo.Add(new MailboxAddress(reply, reply));
                }

                message.Subject = mail.Subject;
                BodyBuilder bodyBuilder = new() { HtmlBody = mail.EmailBody.HtmlBody, TextBody = mail.EmailBody.PlainTextBody };
                foreach (string file in mail.Attachment)
                {
                    _ = bodyBuilder.Attachments.Add(file);
                }
                message.Body = bodyBuilder.ToMessageBody();

                SmtpClient client = new();
                try
                {
                    client.Connect(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.None);
                    client.Authenticate(smtpUser, smtpPassword);
                    _ = client.Send(message);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
