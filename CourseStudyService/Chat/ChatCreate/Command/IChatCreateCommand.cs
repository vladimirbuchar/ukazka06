using Core.Base.Command.Create;
using CourseStudyService.Chat.ChatCreate.Dto;
using Model.Edu.Chat;

namespace CourseStudyService.Chat.ChatCreate.Command
{
    public interface IChatCreateCommand : IBaseCreateCommand<ChatDbo, ChatCreateDto>
    {
    }
}