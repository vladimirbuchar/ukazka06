using Core.Base.Dto;

namespace UserService.LinkLifeTime.LinkLifeTimeCreate.Dto
{
    public class LinkLifeTimeServiceCreateDto : CreateDto
    {
        public Guid UserId { get; set; }
        public DateTime EndTime { get; set; }
    }
}
