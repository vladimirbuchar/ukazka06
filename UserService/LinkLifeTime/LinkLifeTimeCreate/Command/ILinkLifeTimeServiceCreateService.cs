using Core.Base.Command.Create;
using Model.Edu.LinkLifeTime;
using UserService.LinkLifeTime.LinkLifeTimeCreate.Dto;

namespace UserService.LinkLifeTime.LinkLifeTimeCreate.Command
{
    public interface ILinkLifeTimeServiceCreateService : IBaseCreateCommand<LinkLifeTimeDbo, LinkLifeTimeServiceCreateDto>
    {
    }
}