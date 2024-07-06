using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using EduRepository.OrganizationRepository;
using EduRepository.SendMessageRepository;
using EduServices.SendMessage.Dto;
using Model.CodeBook;
using Model.Edu.SendMessage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.SendMessage.Validator
{
    public class SendMessageValidator(IOrganizationRepository organizationRepository, ISendMessageRepository repository, ICodeBookRepository<SendMessageTypeDbo> codeBookRepository)
        : BaseValidator<SendMessageDbo, ISendMessageRepository, SendMessageCreateDto, SendMessageDetailDto, SendMessageUpdateDto>(repository),
            ISendMessageValidator
    {
        private readonly HashSet<SendMessageTypeDbo> _sendMessageTypes = codeBookRepository.GetEntities(false);
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override Result<SendMessageDetailDto> IsValid(SendMessageCreateDto create)
        {
            Result<SendMessageDetailDto> result = new();
            IsValidString(create.Name, result, Category.SEND_MESSAGE, GlobalValue.STRING_IS_EMPTY);
            IsValidMessageType(create.SendMessageTypeId, create.Reply, result);
            if (_organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.ORGANIZATION, GlobalValue.NOT_EXISTS));
            }
            return result;
        }

        public override Result<SendMessageDetailDto> IsValid(SendMessageUpdateDto update)
        {
            Result<SendMessageDetailDto> result = new();
            IsValidString(update.Name, result, Category.SEND_MESSAGE, GlobalValue.STRING_IS_EMPTY);
            IsValidMessageType(update.SendMessageTypeId, update.Reply, result);
            return result;
        }

        private void IsValidMessageType(Guid messageTypeId, string email, Result result)
        {
            if (messageTypeId == Guid.Empty || _sendMessageTypes.FirstOrDefault(x => x.Id == messageTypeId).IsDefault)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.SEND_MESSAGE, Constants.SELECT_MESSAGE_TYPE));
            }
            if (_sendMessageTypes.FirstOrDefault(x => x.Id == messageTypeId).SystemIdentificator == SendMessageType.EMAIL)
            {
                if (email.IsNullOrEmptyWithTrim())
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.SEND_MESSAGE, Constants.REPLY_EMAIL_IS_EMPTY));
                }
                if (!email.IsValidEmail())
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.SEND_MESSAGE, Constants.REPLY_EMAIL_IS_NOT_VALID));
                }
            }
        }
    }
}
