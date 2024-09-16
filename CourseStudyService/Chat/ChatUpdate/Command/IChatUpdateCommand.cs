using Core.Base.Command.Update;
using CourseStudyService.Chat.ChatUpdate.Dto;
using Model.Edu.Chat;

namespace CourseStudyService.Chat.ChatUpdate.Command
{
    public interface IChatUpdateCommand : IBaseUpdateCommand<ChatDbo, ChatUpdateDto>
    {
    }
}