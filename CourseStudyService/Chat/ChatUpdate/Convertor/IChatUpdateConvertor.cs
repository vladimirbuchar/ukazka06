using Core.Base.Convertor;
using CourseStudyService.Chat.ChatUpdate.Dto;
using Model.Edu.Chat;

namespace CourseStudyService.Chat.ChatUpdate.Convertor
{
    public interface IChatUpdateConvertor : IBaseUpdateConvertor<ChatDbo, ChatUpdateDto>
    {
    }
}