using Core.Base.Command.Create;
using Model.Edu.LinkLifeTime;
using Repository.LinkLifeTime;
using UserService.LinkLifeTime.LinkLifeTimeCreate.Convertor;
using UserService.LinkLifeTime.LinkLifeTimeCreate.Dto;
using UserService.LinkLifeTime.LinkLifeTimeCreate.Validator;

namespace UserService.LinkLifeTime.LinkLifeTimeCreate.Command
{
    public class LinkLifeTimeServiceCreateService : BaseCreateCommand<LinkLifeTimeDbo, ILinkLifeTimeRepository, LinkLifeTimeServiceCreateDto, ILinkLifeTimeServiceCreateConvertor, ILinkLifeTimeServiceCreateValidator>, ILinkLifeTimeServiceCreateService
    {
        public LinkLifeTimeServiceCreateService(ILinkLifeTimeRepository repository, ILinkLifeTimeServiceCreateConvertor convertor, ILinkLifeTimeServiceCreateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
