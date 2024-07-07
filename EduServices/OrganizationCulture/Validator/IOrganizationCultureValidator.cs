using Core.Base.Validator;
using Model.Link;
using Repository.OrganizationCultureRepository;
using Services.OrganizationCulture.Dto;

namespace Services.OrganizationCulture.Validator
{
    public interface IOrganizationCultureValidator
        : IBaseValidator<OrganizationCultureDbo, IOrganizationCultureRepository, OrganizationCultureCreateDto, OrganizationCultureDetailDto, OrganizationCultureUpdateDto>
    { }
}
