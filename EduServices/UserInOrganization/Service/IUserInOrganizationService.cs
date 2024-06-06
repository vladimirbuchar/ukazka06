using System;
using System.Collections.Generic;
using Core.Base.Service;
using EduServices.OrganizationRole.Dto;
using EduServices.UserInOrganization.Dto;
using Model.Tables.Link;

namespace EduServices.UserInOrganization.Service
{
    public interface IUserInOrganizationService : IBaseService<UserInOrganizationDbo, UserInOrganizationCreateDto, UserInOrganizationListDto, UserInOrganizationDetailDto, UserInOrganizationUpdateDto>
    {
        HashSet<OrganizationRoleListDto> GetOrganizationRoles();
        UserOrganizationRoleDetailDto CanCourseBrowse(Guid courseId, Guid userId);

        UserOrganizationRoleDetailDto CanShowStudentTestResult(Guid courseId, Guid userId);
    }
}
