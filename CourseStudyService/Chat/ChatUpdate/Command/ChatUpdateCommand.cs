using Core.Base.Command.Update;
using CourseStudyService.Chat.ChatUpdate.Convertor;
using CourseStudyService.Chat.ChatUpdate.Dto;
using CourseStudyService.Chat.ChatUpdate.Validator;
using Model.Edu.Chat;
using Repository.Chat;

namespace CourseStudyService.Chat.ChatUpdate.Command
{
    public class ChatUpdateCommand : BaseUpdateCommand<ChatDbo, IChatRepository, ChatUpdateDto, IChatUpdateConvertor, IChatUpdateValidator>, IChatUpdateCommand
    {
        public ChatUpdateCommand(IChatRepository repository, IChatUpdateConvertor convertor, IChatUpdateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
