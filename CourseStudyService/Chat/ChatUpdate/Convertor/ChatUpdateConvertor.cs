using CourseStudyService.Chat.ChatUpdate.Dto;
using Model.Edu.Chat;

namespace CourseStudyService.Chat.ChatUpdate.Convertor
{
    public class ChatUpdateConvertor : IChatUpdateConvertor
    {
        public Task<ChatDbo> ConvertToBussinessEntity(ChatUpdateDto update, ChatDbo entity, string culture)
        {
            entity.Text = update.Text;
            return Task.FromResult(entity);
        }
    }
}
