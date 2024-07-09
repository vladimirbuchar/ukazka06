using Core.Base.Service;
using Core.DataTypes;
using Services.SystemService.SendMailService.Dto;
using System;
using System.Collections.Generic;

namespace Services.SystemService.SendMailService.Service
{
    public interface ISendMailService : IBaseService
    {
        void AddEmailToQueue(
            string emailIdentificator,
            string culture,
            EmailAddress emailAddressTo,
            Dictionary<string, string> replaceData,
            Guid? organizationId = null,
            string reply = ""
        );
        void AddEmailToQueue(string subject, string html, List<string> attachment, EmailAddress emailAddressTo, Guid organizationId, string reply);
        List<SendMailListDto> GetList(Guid orgranizationId);
        SendMaiDetailDto GetDetail(Guid id);
        SendMaiDetailDto Update(SendMailUpdateDto updateDto, Guid userId);
    }
}
