using Core.Base.Service;
using Model.Edu.Message;
using Services.Message.Dto;
using Services.Message.Filter;

namespace Services.Message.Service
{
    public interface IMessageService
        : IBaseService<MessageDbo, MessageCreateDto, MessageListDto, MessageDetailDto, MessageUpdateDto, MessageFilter> { }
}
