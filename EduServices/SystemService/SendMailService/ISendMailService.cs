using System;
using System.Collections.Generic;
using Core.Base.Service;
using Core.DataTypes;

namespace EduServices.SystemService.SendMailService
{
    public interface ISendMailService : IBaseService
    {
        void AddEmailToQueue(string emailIdentificator, string culture, EmailAddress emailAddressTo, Dictionary<string, string> replaceData, Guid? organizationId = null, string reply = "");
        void AddEmailToQueue(string subject, string html, List<string> attachment, EmailAddress emailAddressTo, Guid organizationId, string reply);
        void SendEmail();
    }
}
