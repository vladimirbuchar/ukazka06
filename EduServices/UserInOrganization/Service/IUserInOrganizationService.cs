using Core.Base.Service;
using Model.Link;
using Services.OrganizationRole.Dto;
using Services.UserInOrganization.Dto;
using Services.UserInOrganization.Filter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<List<OrganizationRoleListDto>> GetOrganizationRoles();
        Task<UserOrganizationRoleDetailDto> CanCourseBrowse(Guid courseId, Guid userId);
        Task<UserOrganizationRoleDetailDto> CanShowStudentTestResult(Guid courseId, Guid userId);
    }
}
