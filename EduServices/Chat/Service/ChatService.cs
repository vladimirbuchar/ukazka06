using Core.Base.Service;
using EduRepository.ChatRepository;
using EduServices.Chat.Convertor;
using EduServices.Chat.Dto;
using EduServices.Chat.Validator;
using Model.Tables.Edu.Chat;

namespace EduServices.Chat.Service
{
    public class ChatService(IChatRepository chatRepository, IChatConvertor chatConvertor, IChatValidator validator)
        : BaseService<IChatRepository, ChatDbo, IChatConvertor, IChatValidator, ChatItemCreateDto, ChatItemListDto, ChatItemDetailDto, ChatItemUpdateDto>(chatRepository, chatConvertor, validator),
            IChatService { }
}
