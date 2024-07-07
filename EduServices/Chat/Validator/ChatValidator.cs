using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.Chat;
using Repository.ChatRepository;
using Repository.CourseTermRepository;
using Repository.UserRepository;
using Services.Chat.Dto;

namespace Services.Chat.Validator
{
    public class ChatValidator(IChatRepository repository, IUserRepository userRepository, ICourseTermRepository courseTermRepository)
        : BaseValidator<ChatDbo, IChatRepository, ChatItemCreateDto, ChatItemDetailDto, ChatItemUpdateDto>(repository),
            IChatValidator
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ICourseTermRepository _courseTermRepository = courseTermRepository;

        public override Result<ChatItemDetailDto> IsValid(ChatItemCreateDto create)
        {
            Result<ChatItemDetailDto> result = new();
            IsValidString(create.Text, result, MessageCategory.CHAT, MessageItem.STRING_IS_EMPTY);
            if (_userRepository.GetEntity(create.UserId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER, MessageItem.NOT_EXISTS));
            }
            if (_courseTermRepository.GetEntity(create.CourseTermId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_TERM, MessageItem.NOT_EXISTS));
            }
            return result;
        }

        public override Result<ChatItemDetailDto> IsValid(ChatItemUpdateDto update)
        {
            Result<ChatItemDetailDto> result = new();
            IsValidString(update.Text, result, MessageCategory.CHAT, MessageItem.STRING_IS_EMPTY);
            return result;
        }
    }
}
