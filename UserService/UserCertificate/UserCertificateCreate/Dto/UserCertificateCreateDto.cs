using Core.Base.Dto;

namespace UserService.UserCertificate.UserCertificateCreate.Dto
{
    public class UserCertificateCreateDto : CreateDto
    {

        public string? Name { get; set; }
        public string? FileName { get; set; }
        public Guid UserId { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
