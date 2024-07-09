using System;
using Core.Base.Dto;

namespace Services.Message.Dto
{
    public class MessageListDto : ListDto
    {
        public string Name { get; set; }
        public Guid SendMessageTypeId { get; set; }
        public string Reply { get; set; }
    }
}
