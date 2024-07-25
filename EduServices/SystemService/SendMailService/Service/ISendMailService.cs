using Core.Base.Service;
using Core.DataTypes;
using Services.SystemService.SendMailService.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.SystemService.SendMailService.Service
{
    public interface ISendMailService : IBaseService
    {
        Task AddEmailToQueue(
            string emailIdentificator,
            string culture,
            EmailAddress emailAddressTo,
            Dictionary<string, string> replaceData,
            Guid? organizationId = null,
            string reply = ""
        );
        Task AddEmailToQueue(string subject, string html, List<string> attachment, EmailAddress emailAddressTo, Guid organizationId, string reply);
        Task<List<SendMailListDto>> GetList(Guid orgranizationId);
        Task<SendMaiDetailDto> GetDetail(Guid id);
        Task<SendMaiDetailDto> Update(SendMailUpdateDto updateDto, Guid userId);
    }
}
