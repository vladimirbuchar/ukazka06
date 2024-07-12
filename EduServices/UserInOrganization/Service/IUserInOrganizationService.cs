using System;
using System.Collections.Generic;
using Core.Base.Service;
using Model.Link;
using Services.OrganizationRole.Dto;
using Services.UserInOrganization.Dto;
using Services.UserInOrganization.Filter;

namespace Services.UserInOrganization.Service
{
    public interface IUserInOrganizationService
        : IBaseService<
            UserInOrganizationDbo,
            UserInOrganizationCreateDto,
            UserInOrganizationListDto,
            UserInOrganizationDetailDto,
            UserInOrganizationUpdateDto,
            UserInOrganizationFilter
        >
    {
        List<OrganizationRoleListDto> GetOrganizationRoles();
        UserOrganizationRoleDetailDto CanCourseBrowse(Guid courseId, Guid userId);
        UserOrganizationRoleDetailDto CanShowStudentTestResult(Guid courseId, Guid userId);
    }
}
