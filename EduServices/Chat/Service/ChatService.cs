using Core.Base.Service;
using Model.Edu.Chat;
using Repository.ChatRepository;
using Services.Chat.Convertor;
using Services.Chat.Dto;
using Services.Chat.Validator;

namespace Services.Chat.Service
{
    public class ChatService(IChatRepository chatRepository, IChatConvertor chatConvertor, IChatValidator validator)
        : BaseService<IChatRepository, ChatDbo, IChatConvertor, IChatValidator, ChatItemCreateDto, ChatItemListDto, ChatItemDetailDto, ChatItemUpdateDto>(chatRepository, chatConvertor, validator),
            IChatService
    { }
}
