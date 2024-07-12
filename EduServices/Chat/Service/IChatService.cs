using Core.Base.Filter;
using Core.Base.Service;
using Model.Edu.Chat;
using Services.Chat.Dto;

namespace Services.Chat.Service
{
    public interface IChatService : IBaseService<ChatDbo, ChatItemCreateDto, ChatItemListDto, ChatItemDetailDto, ChatItemUpdateDto, FilterRequest> { }
}
