using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.Chat.ChatList.Dto;
using Model.Edu.Chat;

namespace CourseStudyService.Chat.ChatList.Command
{
    public interface IChatListCommand : IBaseListCommand<ChatDbo, ChatListDto, RequestFilter>
    {
    }
}