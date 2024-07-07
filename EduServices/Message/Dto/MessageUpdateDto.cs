using Core.Base.Dto;
using System;

namespace Services.Message.Dto
{

    public class MessageUpdateDto : UpdateDto
    {
        public string Name { get; set; }
        public string Html { get; set; }
        public Guid SendMessageTypeId { get; set; }
        public string Reply { get; set; }
    }
}
