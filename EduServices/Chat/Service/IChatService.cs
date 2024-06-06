using Core.Base.Service;
using EduServices.Chat.Dto;
using Model.Tables.Edu.Chat;

namespace EduServices.Chat.Service
{
    public interface IChatService : IBaseService<ChatDbo, ChatItemCreateDto, ChatItemListDto, ChatItemDetailDto, ChatItemUpdateDto> { }
}
