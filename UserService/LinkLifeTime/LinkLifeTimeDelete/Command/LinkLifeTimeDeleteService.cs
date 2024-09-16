using Core.Base.Command.Delete;
using Model.Edu.LinkLifeTime;
using Repository.LinkLifeTime;

namespace UserService.LinkLifeTime.LinkLifeTimeDelete.Command
{
    public class LinkLifeTimeDeleteService : BaseDeleteCommand<LinkLifeTimeDbo, ILinkLifeTimeRepository>, ILinkLifeTimeDeleteService
    {
        public LinkLifeTimeDeleteService(ILinkLifeTimeRepository repository) : base(repository)
        {
        }
    }
}
