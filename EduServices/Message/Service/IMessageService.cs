﻿using System;
using System.Collections.Generic;
using Core.Base.Service;
using Model.Edu.SendMessage;
using Services.Message.Dto;

namespace Services.Message.Service
{
    public interface IMessageService : IBaseService<MessageDbo, MessageCreateDto, MessageListDto, MessageDetailDto, MessageUpdateDto>
    {
        HashSet<MessageListDto> GetSendMessageInOrganizationEmail(Guid organizationId, string culture = "");
    }
}