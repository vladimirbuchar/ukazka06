using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Model.CodeBook;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateDetail.Dto;
using OrganizationService.MessageTemplate.MessageTemplateUpdate.Dto;
using Repository.MessageTemplate;

namespace OrganizationService.MessageTemplate.MessageTemplateUpdate.Validator
{
    public class MessageTemplateUpdateValidator : BaseUpdateValidator<MessageTemplateDbo, IMessageTemplateRepository, MessageUpdateDto>, IMessageTemplateUpdateValidator
    {
        private readonly ICodeBookRepository<MessageTemplateTypeDbo> _sendMessageTypes;

        public MessageTemplateUpdateValidator(IMessageTemplateRepository repository, ICodeBookRepository<MessageTemplateTypeDbo> sendMessageTypes)
            : base(repository)
        {
            _sendMessageTypes = sendMessageTypes;
        }

        public override async Task<Result> IsValid(MessageUpdateDto update)
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
