using Core.Base.Validator;
using Model.Edu.LinkLifeTime;
using UserService.LinkLifeTime.LinkLifeTimeCreate.Dto;

namespace UserService.LinkLifeTime.LinkLifeTimeCreate.Validator
{
    public interface ILinkLifeTimeServiceCreateValidator : IBaseCreateValidator<LinkLifeTimeDbo, LinkLifeTimeServiceCreateDto>
    {
    }
}