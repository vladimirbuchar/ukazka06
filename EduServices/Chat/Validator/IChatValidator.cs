using Core.Base.Validator;
using Model.Edu.Chat;
using Repository.ChatRepository;
using Services.Chat.Dto;

namespace Services.Chat.Validator
{
    public interface IChatValidator : IBaseValidator<ChatDbo, IChatRepository, ChatItemCreateDto, ChatItemDetailDto, ChatItemUpdateDto> { }
}
