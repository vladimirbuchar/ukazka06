﻿using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Message;
using Services.Message.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Message.Convertor
{
    public class MessageConvertor(ICodeBookRepository<CultureDbo> codeBookRepository) : IMessageConvertor
    {
        private readonly List<CultureDbo> _cultureList = codeBookRepository.GetEntities(false).Result;

        public Task<List<MessageListDto>> ConvertToWebModel(List<MessageDbo> getSendMessageInOrganizations, string culture)
        {
            return Task.FromResult(getSendMessageInOrganizations
                .Select(x => new MessageListDto()
                {
                    Id = x.Id,
                    Name = x.SendMessageTranslations.FindTranslation(culture)?.Subject,
                    Reply = x.Reply,
                    SendMessageTypeId = x.SendMessageTypeId,
                    SendMessageTypeName = x.SendMessageType.Name
                })
                .ToList());
        }

        public Task<MessageDetailDto> ConvertToWebModel(MessageDbo getSendMessageDetail, string culture)
        {
            return Task.FromResult(new MessageDetailDto()
            {
                Html = getSendMessageDetail.SendMessageTranslations.FindTranslation(culture).Html,
                Id = getSendMessageDetail.Id,
                Name = getSendMessageDetail.SendMessageTranslations.FindTranslation(culture).Subject,
                Reply = getSendMessageDetail.Reply,
                SendMessageType = getSendMessageDetail.SendMessageTypeId,
            });
        }

        public Task<MessageDbo> ConvertToBussinessEntity(MessageCreateDto addSendMessageDto, string clientCulture)
        {
            MessageDbo sendMessage =
                new()
                {
                    OrganizationId = addSendMessageDto.OrganizationId,
                    Reply = addSendMessageDto.Reply,
                    SendMessageTypeId = addSendMessageDto.SendMessageTypeId
                };
            sendMessage.SendMessageTranslations = sendMessage.SendMessageTranslations.PrepareTranslation(
                addSendMessageDto.Name,
                addSendMessageDto.Html,
                clientCulture,
                _cultureList
            );
            return Task.FromResult(sendMessage);
        }

        public Task<MessageDbo> ConvertToBussinessEntity(MessageUpdateDto updateSendMessageDto, MessageDbo entity, string culture)
        {
            entity.SendMessageTranslations = entity.SendMessageTranslations.PrepareTranslation(
                updateSendMessageDto.Name,
                updateSendMessageDto.Html,
                culture,
                _cultureList
            );
            entity.Reply = updateSendMessageDto.Reply;
            entity.SendMessageTypeId = updateSendMessageDto.SendMessageTypeId;
            return Task.FromResult(entity);
        }
    }
}
