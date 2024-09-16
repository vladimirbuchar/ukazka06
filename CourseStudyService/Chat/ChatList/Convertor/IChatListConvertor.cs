using Core.Base.Convertor;
using CourseStudyService.Chat.ChatList.Dto;
using Model.Edu.Chat;

namespace CourseStudyService.Chat.ChatList.Convertor
{
    public interface IChatListConvertor : IBaseListConvertor<ChatDbo, ChatListDto>
    {
    }
}