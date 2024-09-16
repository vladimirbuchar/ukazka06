using Core.Base.Command.Create;
using CourseStudyService.Chat.ChatCreate.Convertor;
using CourseStudyService.Chat.ChatCreate.Dto;
using CourseStudyService.Chat.ChatCreate.Validator;
using Model.Edu.Chat;
using Repository.Chat;

namespace CourseStudyService.Chat.ChatCreate.Command
{
    public class ChatCreateCommand : BaseCreateCommand<ChatDbo, IChatRepository, ChatCreateDto, IChatCreateConvertor, IChatCreateValidator>, IChatCreateCommand
    {
        public ChatCreateCommand(IChatRepository repository, IChatCreateConvertor convertor, IChatCreateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
