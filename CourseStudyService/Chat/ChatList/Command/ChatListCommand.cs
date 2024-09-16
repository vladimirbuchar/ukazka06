using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.Chat.ChatList.Convertor;
using CourseStudyService.Chat.ChatList.Dto;
using Model.Edu.Chat;
using Repository.Chat;

namespace CourseStudyService.Chat.ChatList.Command
{
    public class ChatListCommand : BaseListCommand<ChatDbo, IChatRepository, ChatListDto, IChatListConvertor, RequestFilter>, IChatListCommand
    {
        public ChatListCommand(IChatRepository repository, IChatListConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
