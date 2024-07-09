using System.Collections.Generic;
using System.Linq;
using Core.Extension;
using Model.Edu.Chat;
using Services.Chat.Dto;

namespace Services.Chat.Convertor
{
    public class ChatConvertor : IChatConvertor
    {
        public ChatConvertor() { }

        public ChatDbo ConvertToBussinessEntity(ChatItemCreateDto addChatItemDto, string culture)
        {
            return new ChatDbo()
            {
                CourseTermId = addChatItemDto.CourseTermId,
                Text = addChatItemDto.Text,
                UserId = addChatItemDto.UserId
            };
        }

        public ChatDbo ConvertToBussinessEntity(ChatItemUpdateDto updateChatItemDto, ChatDbo entity, string culture)
        {
            entity.Text = updateChatItemDto.Text;
            return entity;
        }

        public List<ChatItemListDto> ConvertToWebModel(List<ChatDbo> getAllChatItems, string culture)
        {
            return getAllChatItems
                .Select(x => new ChatItemListDto()
                {
                    Id = x.Id,
                    Text = x.Text,
                    //ParentId = x.ChatId,
                    UserId = x.UserId,
                    IsAvatarUrl = !x.User.Person.AvatarUrl.IsNullOrEmptyWithTrim() && x.User.Person.AvatarUrl.IsValidUri(),
                    Avatar =
                        x.User.Person.AvatarUrl == null
                            ? string.Format("{0}{1}", x.User.Person.FirstName.FirstOrDefault(), x.User.Person.LastName.FirstOrDefault())
                            : x.User.Person.AvatarUrl.IsValidUri()
                                ? x.User.Person.AvatarUrl
                                : string.Format("{0}{1}", x.User.Person.FirstName.FirstOrDefault(), x.User.Person.LastName.FirstOrDefault()),
                    FirstName = x.User.Person.FirstName,
                    LastName = x.User.Person.LastName,
                    SecondName = x.User.Person.SecondName,
                    Date = x.Date,
                    /*IsAuthor = x.,
                    Answers = x.Answers.Select(y => new GetAllChatItemDto()
                    {
                        Id = y.Id,
                        Text = y.Text,
                        ParentId = y.ParentId,
                        UserId = y.UserId,
                        IsAvatarUrl = y.AvatarUrl.IsNullOrEmptyWithTrim() ? false : y.AvatarUrl.IsValidUri(),
                        Avatar = y.AvatarUrl == null ? string.Format("{0}{1}", y.FirstName.FirstOrDefault(), y.LastName.FirstOrDefault()) : (y.AvatarUrl.IsValidUri() ? y.AvatarUrl : string.Format("{0}{1}", y.FirstName.FirstOrDefault(), y.LastName.FirstOrDefault())),
                        FirstName = y.FirstName,
                        LastName = y.LastName,
                        SecondName = y.SecondName,
                        Date = y.Date,
                        IsAuthor = y.IsAuthor
    
                    }).ToHashSet()*/
                })
                .ToList();
        }

        public ChatItemDetailDto ConvertToWebModel(ChatDbo detail, string culture)
        {
            return new ChatItemDetailDto()
            {
                Avatar = detail.User.Person.AvatarUrl,
                Answers = [],
                Date = detail.Date,
                FirstName = detail.User.Person.FirstName,
                Id = detail.Id,
                LastName = detail.User.Person.LastName,
                UserId = detail.UserId,
                Text = detail.Text,
                SecondName = detail.User.Person.SecondName
            };
        }
    }
}
