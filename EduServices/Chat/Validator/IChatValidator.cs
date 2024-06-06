using Core.Base.Validator;
using EduRepository.ChatRepository;
using EduServices.Chat.Dto;
using Model.Tables.Edu.Chat;

namespace EduServices.Chat.Validator
{
    public interface IChatValidator : IBaseValidator<ChatDbo, IChatRepository, ChatItemCreateDto, ChatItemDetailDto, ChatItemUpdateDto> { }
}
