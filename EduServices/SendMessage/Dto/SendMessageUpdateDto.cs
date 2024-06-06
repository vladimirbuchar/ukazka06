using Core.Base.Dto;
using System;

namespace EduServices.SendMessage.Dto
{

    public class SendMessageUpdateDto : UpdateDto
    {
        public string Name { get; set; }
        public string Html { get; set; }
        public Guid SendMessageTypeId { get; set; }
        public string Reply { get; set; }
    }
}
