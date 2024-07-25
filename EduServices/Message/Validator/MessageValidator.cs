using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Model.CodeBook;
using Model.Edu.Message;
using Repository.MessageRepository;
using Repository.OrganizationRepository;
using Services.Message.Dto;
using System;
using System.Threading.Tasks;

namespace Services.Message.Validator
{
    public class MessageValidator(
        IOrganizationRepository organizationRepository,
        IMessageRepository repository,
        ICodeBookRepository<SendMessageTypeDbo> codeBookRepository
    ) : BaseValidator<MessageDbo, IMessageRepository, MessageCreateDto, MessageDetailDto, MessageUpdateDto>(repository), IMessageValidator
    {
        private readonly ICodeBookRepository<SendMessageTypeDbo> _sendMessageTypes = codeBookRepository;
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override async Task<Result> IsValid(MessageCreateDto create)
        {
            Result<MessageDetailDto> result = new();
            IsValidString(create.Name, result, MessageCategory.SEND_MESSAGE, MessageItem.STRING_IS_EMPTY);
            await IsValidMessageType(create.SendMessageTypeId, create.Reply, result);
            if (await _organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            return result;
        }

        public override async Task<Result<MessageDetailDto>> IsValid(MessageUpdateDto update)
        {
            Result<MessageDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.SEND_MESSAGE, MessageItem.STRING_IS_EMPTY);
            await IsValidMessageType(update.SendMessageTypeId, update.Reply, result);
            return await Task.FromResult(result);
        }

        private async Task IsValidMessageType(Guid messageTypeId, string email, Result result)
        {
            if (messageTypeId == Guid.Empty || (await _sendMessageTypes.GetEntity(false, x => x.Id == messageTypeId)).IsDefault)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.SEND_MESSAGE, Constants.SELECT_MESSAGE_TYPE));
            }
            if ((await _sendMessageTypes.GetEntity(false, x => x.Id == messageTypeId)).SystemIdentificator == SendMessageType.EMAIL)
            {
                if (email.IsNullOrEmptyWithTrim())
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.SEND_MESSAGE, Constants.REPLY_EMAIL_IS_EMPTY));
                }
                if (!email.IsValidEmail())
                {
                    result.AddResultStatus(
                        new ValidationMessage(MessageType.ERROR, MessageCategory.SEND_MESSAGE, Constants.REPLY_EMAIL_IS_NOT_VALID)
                    );
                }
            }
        }
    }
}
