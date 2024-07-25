using Core.Base.Validator;
using Core.DataTypes;
using Model.Edu.Organization;
using Repository.OrganizationRepository;
using Services.Organization.Dto;
using Services.OrganizationSetting.Dto;
using System.Threading.Tasks;

namespace Services.OrganizationSetting.Validator
{
    public interface IOrganizationSettingValidator
        : IBaseValidator<OrganizationDbo, IOrganizationRepository, OrganizationCreateDto, OrganizationDetailDto, OrganizationUpdateDto>
    {
        Task<Result> IsValid(OrganizationSettingUpdateDto validate);
    }
}
