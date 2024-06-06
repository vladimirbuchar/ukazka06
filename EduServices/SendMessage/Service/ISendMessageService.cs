using System;
using System.Collections.Generic;
using Core.Base.Service;
using EduServices.SendMessage.Dto;
using Model.Tables.Edu.SendMessage;

namespace EduServices.SendMessage.Service
{
    public interface ISendMessageService : IBaseService<SendMessageDbo, SendMessageCreateDto, SendMessageListDto, SendMessageDetailDto, SendMessageUpdateDto>
    {
        HashSet<SendMessageListDto> GetSendMessageInOrganizationEmail(Guid organizationId, string culture = "");
    }
}
