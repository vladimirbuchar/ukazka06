using System;
using Core.Base.Dto;

namespace EduServices.SendMessage.Dto
{
    public class SendMessageDetailDto : DetailDto
    {
        public string Name { get; set; }
        public string Html { get; set; }
        public Guid SendMessageType { get; set; }
        public string Reply { get; set; }
    }
}
