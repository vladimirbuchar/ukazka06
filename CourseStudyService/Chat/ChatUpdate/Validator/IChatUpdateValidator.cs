using Core.Base.Validator;
using CourseStudyService.Chat.ChatUpdate.Dto;
using Model.Edu.Chat;

namespace CourseStudyService.Chat.ChatUpdate.Validator
{
    public interface IChatUpdateValidator : IBaseUpdateValidator<ChatDbo, ChatUpdateDto>
    {
    }
}