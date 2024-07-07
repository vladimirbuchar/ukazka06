using Core.Base.Service;
using Model.Link;
using Services.OrganizationRole.Dto;
using Services.UserInOrganization.Dto;
using System;
using System.Collections.Generic;

namespace Services.UserInOrganization.Service
{
    public interface IUserInOrganizationService : IBaseService<UserInOrganizationDbo, UserInOrganizationCreateDto, UserInOrganizationListDto, UserInOrganizationDetailDto, UserInOrganizationUpdateDto>
    {
        HashSet<OrganizationRoleListDto> GetOrganizationRoles();
        UserOrganizationRoleDetailDto CanCourseBrowse(Guid courseId, Guid userId);

        UserOrganizationRoleDetailDto CanShowStudentTestResult(Guid courseId, Guid userId);
    }
}
