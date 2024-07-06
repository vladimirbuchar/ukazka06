using System.Collections.Generic;
using Core.Base.Convertor;
using EduServices.UserInOrganization.Dto;
using Model.Edu.OrganizationRole;
using Model.Link;

namespace EduServices.UserInOrganization.Convertor
{
    public interface IUserInOrganizationConvertor
        : IBaseConvertor<UserInOrganizationDbo, UserInOrganizationCreateDto, UserInOrganizationListDto, UserInOrganizationDetailDto, UserInOrganizationUpdateDto>
    {
        HashSet<OrganizationRoleListDto> ConvertToWebModel(HashSet<OrganizationRoleDbo> organizationRoles);
    }
}
