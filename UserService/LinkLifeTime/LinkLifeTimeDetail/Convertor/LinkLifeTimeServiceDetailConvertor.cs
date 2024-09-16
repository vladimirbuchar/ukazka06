using Model.Edu.LinkLifeTime;
using UserService.LinkLifeTime.LinkLifeTimeDetail.Dto;

namespace UserService.LinkLifeTime.LinkLifeTimeDetail.Convertor
{
    public class LinkLifeTimeServiceDetailConvertor : ILinkLifeTimeServiceDetailConvertor
    {
        public Task<LinkLifeTimeServiceDetailDto> ConvertToWebModel(LinkLifeTimeDbo detail, List<string> culture)
        {
            return Task.FromResult(new LinkLifeTimeServiceDetailDto()
            {
                EndTime = detail.EndTime,
                Id = detail.Id,
                UserId = detail.UserId,
            });
        }
    }
}
