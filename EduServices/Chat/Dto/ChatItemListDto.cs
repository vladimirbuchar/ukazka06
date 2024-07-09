using System;
using System.Collections.Generic;
using Core.Base.Dto;
using Core.Extension;

namespace Services.Chat.Dto
{
    public class ChatItemListDto : ListDto
    {
        public ChatItemListDto()
        {
            Answers = [];
        }

        public string Text { get; set; }
        public Guid? ParentId { get; set; }
        public Guid UserId { get; set; }
        public bool IsAvatarUrl { get; set; }
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public DateTime Date { get; set; }
        public bool IsAuthor { get; set; }
        public string FullName =>
            FirstName.IsNullOrEmptyWithTrim() && SecondName.IsNullOrEmptyWithTrim() && LastName.IsNullOrEmptyWithTrim()
                ? string.Empty
                : SecondName.IsNullOrEmptyWithTrim()
                    ? string.Format("{0} {1}", FirstName.Trim(), LastName.Trim())
                    : string.Format("{0} {1} {2}", FirstName.Trim(), SecondName.Trim(), LastName.Trim());
        public List<ChatItemListDto> Answers { get; set; }
    }
}
