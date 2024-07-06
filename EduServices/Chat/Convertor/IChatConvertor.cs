using Core.Base.Convertor;
using EduServices.Chat.Dto;
using Model.Edu.Chat;

namespace EduServices.Chat.Convertor
{
    public interface IChatConvertor : IBaseConvertor<ChatDbo, ChatItemCreateDto, ChatItemListDto, ChatItemDetailDto, ChatItemUpdateDto> { }
}
