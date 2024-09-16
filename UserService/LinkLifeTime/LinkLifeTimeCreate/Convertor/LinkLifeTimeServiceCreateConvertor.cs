using Model.Edu.LinkLifeTime;
using UserService.LinkLifeTime.LinkLifeTimeCreate.Dto;

namespace UserService.LinkLifeTime.LinkLifeTimeCreate.Convertor
{
    public class LinkLifeTimeServiceCreateConvertor : ILinkLifeTimeServiceCreateConvertor
    {
        public Task<LinkLifeTimeDbo> ConvertToBussinessEntity(LinkLifeTimeServiceCreateDto create, string culture)
        {
            return Task.FromResult(new LinkLifeTimeDbo()
            {
                UserId = create.UserId,
                EndTime = create.EndTime
            });
        }
    }
}
