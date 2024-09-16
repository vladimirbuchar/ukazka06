using Core.Base.Validator;
using CourseStudyService.Chat.ChatCreate.Dto;
using Model.Edu.Chat;

namespace CourseStudyService.Chat.ChatCreate.Validator
{
    public interface IChatCreateValidator : IBaseCreateValidator<ChatDbo, ChatCreateDto>
    {
    }
}