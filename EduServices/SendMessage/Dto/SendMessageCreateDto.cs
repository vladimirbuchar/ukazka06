using Core.Base.Dto;
using System;

namespace EduServices.SendMessage.Dto
{
    public class SendMessageCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public string Html { get; set; }
        public Guid SendMessageTypeId { get; set; }
        public string Reply { get; set; }
    }


}
