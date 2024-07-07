using Core.Base.Dto;
using System;

namespace Services.Message.Dto
{
    public class MessageDetailDto : DetailDto
    {
        public string Name { get; set; }
        public string Html { get; set; }
        public Guid SendMessageType { get; set; }
        public string Reply { get; set; }
    }
}
