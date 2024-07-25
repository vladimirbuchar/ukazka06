using Core.Base.Convertor;
using Model.Edu.OrganizationRole;
using Model.Link;
using Services.UserInOrganization.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.UserInOrganization.Convertor
{
    public interface IUserInOrganizationConvertor
        : IBaseConvertor<
            UserInOrganizationDbo,
            UserInOrganizationCreateDto,
            UserInOrganizationListDto,
            UserInOrganizationDetailDto,
            UserInOrganizationUpdateDto
        >
    {
        Task<List<OrganizationRoleListDto>> ConvertToWebModel(List<OrganizationRoleDbo> organizationRoles);
    }
}
