using Core.Base.Validator;
using Core.DataTypes;
using Model.Edu.Organization;
using Repository.OrganizationRepository;
using Services.Organization.Dto;
using Services.OrganizationSetting.Dto;

namespace Services.OrganizationSetting.Validator
{
    public interface IOrganizationSettingValidator : IBaseValidator<OrganizationDbo, IOrganizationRepository, OrganizationCreateDto, OrganizationDetailDto, OrganizationUpdateDto>
    {
        Result IsValid(OrganizationSettingUpdateDto validate);
    }
}
