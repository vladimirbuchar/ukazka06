using Core.Base.Validator;
using Model.Edu.LinkLifeTime;
using Repository.LinkLifeTime;
using UserService.LinkLifeTime.LinkLifeTimeCreate.Dto;

namespace UserService.LinkLifeTime.LinkLifeTimeCreate.Validator
{
    public class LinkLifeTimeServiceCreateValidator : BaseCreateValidator<LinkLifeTimeDbo, ILinkLifeTimeRepository, LinkLifeTimeServiceCreateDto>, ILinkLifeTimeServiceCreateValidator
    {
        public LinkLifeTimeServiceCreateValidator(ILinkLifeTimeRepository repository) : base(repository)
        {
        }
    }
}
