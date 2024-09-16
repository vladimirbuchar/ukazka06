using Core.Extension;
using CourseStudyService.Chat.ChatList.Dto;
using Model.Edu.Chat;

namespace CourseStudyService.Chat.ChatList.Convertor
{
    public class ChatListConvertor : IChatListConvertor
    {
        public Task<List<ChatListDto>> ConvertToWebModel(List<ChatDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list
                    .Select(x => new ChatListDto()
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
                        /*IsAuthor = x
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
                    .ToList()
            );
        }
    }
}
