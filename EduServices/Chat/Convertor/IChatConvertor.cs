using Core.Base.Convertor;
using Model.Edu.Chat;
using Services.Chat.Dto;

namespace Services.Chat.Convertor
{
    public interface IChatConvertor : IBaseConvertor<ChatDbo, ChatItemCreateDto, ChatItemListDto, ChatItemDetailDto, ChatItemUpdateDto> { }
}
