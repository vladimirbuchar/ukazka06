using Core.Base.Dto;

namespace UserService.UserProfile.MyCertificate.Dto
{
    public class MyCertificateListDto : ListDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime ActiveFrom { get; set; }
        public string? FileName { get; set; }
    }
}
