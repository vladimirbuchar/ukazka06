using CourseStudyService.Chat.ChatCreate.Dto;
using Model.Edu.Chat;

namespace CourseStudyService.Chat.ChatCreate.Convertor
{
    public class ChatCreateConvertor : IChatCreateConvertor
    {
        public Task<ChatDbo> ConvertToBussinessEntity(ChatCreateDto create, string culture)
        {
            return Task.FromResult(
                new ChatDbo()
                {
                    CourseTermId = create.CourseTermId,
                    Text = create.Text,
                    UserId = create.UserId
                }
            );
        }
    }
}
