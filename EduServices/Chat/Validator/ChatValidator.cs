﻿using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.ChatRepository;
using EduRepository.CourseTermRepository;
using EduRepository.UserRepository;
using EduServices.Chat.Dto;
using Model.Tables.Edu.Chat;

namespace EduServices.Chat.Validator
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
            IsValidString(create.Text, result, ErrorCategory.CHAT, GlobalValue.STRING_IS_EMPTY);
            if (_userRepository.GetEntity(create.UserId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.USER, GlobalValue.NOT_EXISTS));
            }
            if (_courseTermRepository.GetEntity(create.CourseTermId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.COURSE_TERM, GlobalValue.NOT_EXISTS));
            }
            return result;
        }

        public override Result<ChatItemDetailDto> IsValid(ChatItemUpdateDto update)
        {
            Result<ChatItemDetailDto> result = new();
            IsValidString(update.Text, result, ErrorCategory.CHAT, GlobalValue.STRING_IS_EMPTY);
            return result;
        }
    }
}
