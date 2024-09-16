using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseStudyService.Chat.ChatCreate.Dto;
using Model.Edu.Chat;
using Repository.Chat;
using Repository.CourseTerm;
using Repository.User;

namespace CourseStudyService.Chat.ChatCreate.Validator
{
    public class ChatCreateValidator : BaseCreateValidator<ChatDbo, IChatRepository, ChatCreateDto>, IChatCreateValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseTermRepository _courseTermRepository;
        public ChatCreateValidator(IChatRepository repository, IUserRepository userRepository, ICourseTermRepository courseTermRepository) : base(repository)
        {
            _userRepository = userRepository;
            _courseTermRepository = courseTermRepository;
        }

        public override async Task<ResultInsert> IsValid(ChatCreateDto create)
        {
            ResultInsert result = new();
            IsValidString(create.Text, result, MessageCategory.CHAT, MessageItem.STRING_IS_EMPTY);
            if (await _userRepository.GetEntity(create.UserId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER, MessageItem.NOT_EXISTS));
            }
            if (await _courseTermRepository.GetEntity(create.CourseTermId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_TERM, MessageItem.NOT_EXISTS));
            }
            return result;
        }
    }
}
