using Core.DataTypes;

namespace Integration.MailKitIntegration
{
    public interface IMailKitIntegration
    {
        void SendEmail(Email mail);
        void SendEmail(Email mail, string smtpServer, int smtpPort, string smtpUser, string smtpPassword);
    }
}
