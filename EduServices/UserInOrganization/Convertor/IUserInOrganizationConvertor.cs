using Core.Base.Convertor;
using Model.Edu.OrganizationRole;
using Model.Link;
using Services.UserInOrganization.Dto;
using System.Collections.Generic;

namespace Services.UserInOrganization.Convertor
{
    public interface IUserInOrganizationConvertor
        : IBaseConvertor<UserInOrganizationDbo, UserInOrganizationCreateDto, UserInOrganizationListDto, UserInOrganizationDetailDto, UserInOrganizationUpdateDto>
    {
        HashSet<OrganizationRoleListDto> ConvertToWebModel(HashSet<OrganizationRoleDbo> organizationRoles);
    }
}
