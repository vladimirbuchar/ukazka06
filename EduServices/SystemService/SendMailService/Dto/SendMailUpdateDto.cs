using Core.Base.Dto;

namespace Services.SystemService.SendMailService.Dto
{
    public class SendMailUpdateDto : UpdateDto
    {
        public bool IsSended { get; set; }
    }
}
