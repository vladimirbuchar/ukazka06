using System;
using System.Collections.Generic;
using Core.Base.Service;
using Core.Constants;
using Model.Edu.SendMessage;
using Repository.MessageRepository;
using Services.Message.Convertor;
using Services.Message.Dto;
using Services.Message.Validator;

namespace Services.Message.Service
{
    public class MessageService(IMessageRepository sendMessageRepository, IMessageConvertor convertor, IMessageValidator validator)
        : BaseService<IMessageRepository, MessageDbo, IMessageConvertor, IMessageValidator, MessageCreateDto, MessageListDto, MessageDetailDto, MessageUpdateDto>(
            sendMessageRepository,
            convertor,
            validator
        ),
            IMessageService
    {
        public HashSet<MessageListDto> GetSendMessageInOrganizationEmail(Guid organizationId, string culture = "")
        {
            return _convertor.ConvertToWebModel(_repository.GetEntities(false, x => x.OrganizationId == organizationId && x.SystemIdentificator == SendMessageType.EMAIL), culture);
        }
    }
}
