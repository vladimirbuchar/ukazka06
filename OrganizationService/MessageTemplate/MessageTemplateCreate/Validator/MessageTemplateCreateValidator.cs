using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Model.CodeBook;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateCreate.Dto;
using Repository.MessageTemplate;
using Repository.Organization;

namespace OrganizationService.MessageTemplate.MessageTemplateCreate.Validator
{
    public class MessageTemplateCreateValidator : BaseCreateValidator<MessageTemplateDbo, IMessageTemplateRepository, MessageCreateDto>, IMessageTemplateCreateValidator
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICodeBookRepository<MessageTemplateTypeDbo> _sendMessageTypes;

        public MessageTemplateCreateValidator(
            IMessageTemplateRepository repository,
            IOrganizationRepository organizationRepository,
            ICodeBookRepository<MessageTemplateTypeDbo> sendMessageTypes
        )
            : base(repository)
        {
            _organizationRepository = organizationRepository;
            _sendMessageTypes = sendMessageTypes;
        }

        public override async Task<ResultInsert> IsValid(MessageCreateDto create)
        {
            ResultInsert result = new();
            IsValidString(create.Name, result, MessageCategory.SEND_MESSAGE, MessageItem.STRING_IS_EMPTY);
            await IsValidMessageType(create.SendMessageTypeId, create.Reply, result);
            if (await _organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            return result;
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
