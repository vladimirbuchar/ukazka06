using System.Collections.Generic;
using System.Linq;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Message;
using Services.Message.Dto;

namespace Services.Message.Convertor
{
    public class MessageConvertor(ICodeBookRepository<CultureDbo> codeBookService) : IMessageConvertor
    {
        private readonly List<CultureDbo> _cultureList = codeBookService.GetEntities(false).Result;

        public List<MessageListDto> ConvertToWebModel(List<MessageDbo> getSendMessageInOrganizations, string culture)
        {
            return getSendMessageInOrganizations
                .Select(x => new MessageListDto()
                {
                    Id = x.Id,
                    Name = x.SendMessageTranslations.FindTranslation(culture)?.Subject,
                    Reply = x.Reply,
                    SendMessageTypeId = x.SendMessageTypeId
                })
                .ToList();
        }

        public MessageDetailDto ConvertToWebModel(MessageDbo getSendMessageDetail, string culture)
        {
            return new MessageDetailDto()
            {
                Html = getSendMessageDetail.SendMessageTranslations.FindTranslation(culture).Html,
                Id = getSendMessageDetail.Id,
                Name = getSendMessageDetail.SendMessageTranslations.FindTranslation(culture).Subject,
                Reply = getSendMessageDetail.Reply,
                SendMessageType = getSendMessageDetail.SendMessageTypeId,
            };
        }

        public MessageDbo ConvertToBussinessEntity(MessageCreateDto addSendMessageDto, string clientCulture)
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
            return sendMessage;
        }

        public MessageDbo ConvertToBussinessEntity(MessageUpdateDto updateSendMessageDto, MessageDbo entity, string culture)
        {
            entity.SendMessageTranslations = entity.SendMessageTranslations.PrepareTranslation(
                updateSendMessageDto.Name,
                updateSendMessageDto.Html,
                culture,
                _cultureList
            );
            entity.Reply = updateSendMessageDto.Reply;
            entity.SendMessageTypeId = updateSendMessageDto.SendMessageTypeId;
            return entity;
        }
    }
}
