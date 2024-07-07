using System;
using System.Collections.Generic;
using System.Linq;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Model.CodeBook;
using Model.Edu.SendMessage;
using Repository.MessageRepository;
using Repository.OrganizationRepository;
using Services.Message.Dto;

namespace Services.Message.Validator
{
    public class MessageValidator(IOrganizationRepository organizationRepository, IMessageRepository repository, ICodeBookRepository<SendMessageTypeDbo> codeBookRepository)
        : BaseValidator<MessageDbo, IMessageRepository, MessageCreateDto, MessageDetailDto, MessageUpdateDto>(repository),
            IMessageValidator
    {
        private readonly HashSet<SendMessageTypeDbo> _sendMessageTypes = codeBookRepository.GetEntities(false);
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override Result<MessageDetailDto> IsValid(MessageCreateDto create)
        {
            Result<MessageDetailDto> result = new();
            IsValidString(create.Name, result, MessageCategory.SEND_MESSAGE, MessageItem.STRING_IS_EMPTY);
            IsValidMessageType(create.SendMessageTypeId, create.Reply, result);
            if (_organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            return result;
        }

        public override Result<MessageDetailDto> IsValid(MessageUpdateDto update)
        {
            Result<MessageDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.SEND_MESSAGE, MessageItem.STRING_IS_EMPTY);
            IsValidMessageType(update.SendMessageTypeId, update.Reply, result);
            return result;
        }

        private void IsValidMessageType(Guid messageTypeId, string email, Result result)
        {
            if (messageTypeId == Guid.Empty || _sendMessageTypes.FirstOrDefault(x => x.Id == messageTypeId).IsDefault)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.SEND_MESSAGE, Constants.SELECT_MESSAGE_TYPE));
            }
            if (_sendMessageTypes.FirstOrDefault(x => x.Id == messageTypeId).SystemIdentificator == SendMessageType.EMAIL)
            {
                if (email.IsNullOrEmptyWithTrim())
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.SEND_MESSAGE, Constants.REPLY_EMAIL_IS_EMPTY));
                }
                if (!email.IsValidEmail())
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.SEND_MESSAGE, Constants.REPLY_EMAIL_IS_NOT_VALID));
                }
            }
        }
    }
}
