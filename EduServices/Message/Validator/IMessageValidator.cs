using Core.Base.Validator;
using Model.Edu.Message;
using Repository.MessageRepository;
using Services.Message.Dto;

namespace Services.Message.Validator
{
    public interface IMessageValidator : IBaseValidator<MessageDbo, IMessageRepository, MessageCreateDto, MessageDetailDto, MessageUpdateDto> { }
}
