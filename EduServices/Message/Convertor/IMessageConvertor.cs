using Core.Base.Convertor;
using Model.Edu.SendMessage;
using Services.Message.Dto;

namespace Services.Message.Convertor
{
    public interface IMessageConvertor : IBaseConvertor<MessageDbo, MessageCreateDto, MessageListDto, MessageDetailDto, MessageUpdateDto> { }
}
