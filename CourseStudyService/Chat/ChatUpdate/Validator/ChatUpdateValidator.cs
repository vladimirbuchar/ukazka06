using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseStudyService.Chat.ChatUpdate.Dto;
using Model.Edu.Chat;
using Repository.Chat;

namespace CourseStudyService.Chat.ChatUpdate.Validator
{
    public class ChatUpdateValidator : BaseUpdateValidator<ChatDbo, IChatRepository, ChatUpdateDto>, IChatUpdateValidator
    {
        public ChatUpdateValidator(IChatRepository repository) : base(repository)
        {
        }
        public override async Task<Result> IsValid(ChatUpdateDto update)
        {
            Result<Result> result = new();
            IsValidString(update.Text, result, MessageCategory.CHAT, MessageItem.STRING_IS_EMPTY);
            return await Task.FromResult(result);
        }
    }
}
