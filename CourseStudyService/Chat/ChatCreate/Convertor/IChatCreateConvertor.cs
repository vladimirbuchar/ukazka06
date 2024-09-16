using Core.Base.Convertor;
using CourseStudyService.Chat.ChatCreate.Dto;
using Model.Edu.Chat;

namespace CourseStudyService.Chat.ChatCreate.Convertor
{
    public interface IChatCreateConvertor : IBaseCreateConvertor<ChatDbo, ChatCreateDto>
    {
    }
}