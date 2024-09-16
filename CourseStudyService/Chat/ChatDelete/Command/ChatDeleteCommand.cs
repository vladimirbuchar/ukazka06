using Core.Base.Command.Delete;
using Model.Edu.Chat;
using Repository.Chat;

namespace CourseStudyService.Chat.ChatDelete.Command
{
    public class ChatDeleteCommand : BaseDeleteCommand<ChatDbo, IChatRepository>, IChatDeleteCommand
    {
        public ChatDeleteCommand(IChatRepository repository) : base(repository)
        {
        }
    }
}
