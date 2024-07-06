using Core.Base.Service;
using Core.Constants;
using EduRepository.SendMessageRepository;
using EduServices.SendMessage.Convertor;
using EduServices.SendMessage.Dto;
using EduServices.SendMessage.Validator;
using Model.Edu.SendMessage;
using System;
using System.Collections.Generic;

namespace EduServices.SendMessage.Service
{
    public class SendMessageService(ISendMessageRepository sendMessageRepository, ISendMessageConvertor convertor, ISendMessageValidator validator)
        : BaseService<ISendMessageRepository, SendMessageDbo, ISendMessageConvertor, ISendMessageValidator, SendMessageCreateDto, SendMessageListDto, SendMessageDetailDto, SendMessageUpdateDto>(
            sendMessageRepository,
            convertor,
            validator
        ),
            ISendMessageService
    {
        public HashSet<SendMessageListDto> GetSendMessageInOrganizationEmail(Guid organizationId, string culture = "")
        {
            return _convertor.ConvertToWebModel(_repository.GetEntities(false, x => x.OrganizationId == organizationId && x.SystemIdentificator == SendMessageType.EMAIL), culture);
        }
    }
}
