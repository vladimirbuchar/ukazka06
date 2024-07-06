using Core.Base.Repository.CodeBookRepository;
using EduServices.SendMessage.Dto;
using Model.CodeBook;
using Model.Edu.SendMessage;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.SendMessage.Convertor
{
    public class SendMessageConvertor(ICodeBookRepository<CultureDbo> codeBookService) : ISendMessageConvertor
    {
        private readonly HashSet<CultureDbo> _cultureList = codeBookService.GetEntities(false);

        public HashSet<SendMessageListDto> ConvertToWebModel(HashSet<SendMessageDbo> getSendMessageInOrganizations, string culture)
        {
            return getSendMessageInOrganizations.Select(x => new SendMessageListDto() { Id = x.Id, Name = x.SendMessageTranslations.FindTranslation(culture)?.Subject }).ToHashSet();
        }

        public SendMessageDetailDto ConvertToWebModel(SendMessageDbo getSendMessageDetail, string culture)
        {
            return new SendMessageDetailDto()
            {
                Html = getSendMessageDetail.SendMessageTranslations.FindTranslation(culture).Html,
                Id = getSendMessageDetail.Id,
                Name = getSendMessageDetail.SendMessageTranslations.FindTranslation(culture).Subject,
                Reply = getSendMessageDetail.Reply,
                SendMessageType = getSendMessageDetail.SendMessageTypeId,
            };
        }

        public SendMessageDbo ConvertToBussinessEntity(SendMessageCreateDto addSendMessageDto, string clientCulture)
        {
            SendMessageDbo sendMessage =
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

        public SendMessageDbo ConvertToBussinessEntity(SendMessageUpdateDto updateSendMessageDto, SendMessageDbo entity, string culture)
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
