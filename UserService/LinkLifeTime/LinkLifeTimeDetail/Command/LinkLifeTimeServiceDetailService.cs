using Core.Base.Command.Detail;
using Model.Edu.LinkLifeTime;
using Repository.LinkLifeTime;
using UserService.LinkLifeTime.LinkLifeTimeDetail.Convertor;
using UserService.LinkLifeTime.LinkLifeTimeDetail.Dto;

namespace UserService.LinkLifeTime.LinkLifeTimeDetail.Command
{
    public class LinkLifeTimeServiceDetailService : BaseDetailCommand<LinkLifeTimeDbo, ILinkLifeTimeRepository, LinkLifeTimeServiceDetailDto, ILinkLifeTimeServiceDetailConvertor>, ILinkLifeTimeServiceDetailService
    {
        public LinkLifeTimeServiceDetailService(ILinkLifeTimeRepository repository, ILinkLifeTimeServiceDetailConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
