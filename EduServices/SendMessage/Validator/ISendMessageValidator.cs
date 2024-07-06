using Core.Base.Validator;
using EduRepository.SendMessageRepository;
using EduServices.SendMessage.Dto;
using Model.Edu.SendMessage;

namespace EduServices.SendMessage.Validator
{
    public interface ISendMessageValidator : IBaseValidator<SendMessageDbo, ISendMessageRepository, SendMessageCreateDto, SendMessageDetailDto, SendMessageUpdateDto> { }
}
