using Core.Base.Validator;
using Core.DataTypes;
using EduRepository.OrganizationRepository;
using EduServices.Organization.Dto;
using EduServices.OrganizationSetting.Dto;
using Model.Tables.Edu.Organization;

namespace EduServices.OrganizationSetting.Validator
{
    public interface IOrganizationSettingValidator : IBaseValidator<OrganizationDbo, IOrganizationRepository, OrganizationCreateDto, OrganizationDetailDto, OrganizationUpdateDto>
    {
        Result IsValid(OrganizationSettingUpdateDto validate);
    }
}
