using Core.Base.Dto;

namespace UserService.LinkLifeTime.LinkLifeTimeDetail.Dto
{
    public class LinkLifeTimeServiceDetailDto : DetailDto
    {
        public DateTime EndTime { get; set; }
        public Guid UserId { get; set; }
    }
}
