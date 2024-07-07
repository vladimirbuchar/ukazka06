using System;
using Core.Base.Dto;

namespace Services.Chat.Dto
{
    public class ChatItemCreateDto : CreateDto
    {
        public Guid UserId { get; set; }
        public Guid CourseTermId { get; set; }
        public Guid ParentId { get; set; }
        public string Text { get; set; }
    }
}
