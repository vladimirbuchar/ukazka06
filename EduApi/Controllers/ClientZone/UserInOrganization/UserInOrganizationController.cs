using Core.Base.Dto;
using Core.Base.Paging;
using Core.Constants;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Course.Service;
using Services.OrganizationRole.Dto;
using Services.OrganizationRole.Service;
using Services.UserInOrganization.Dto;
using Services.UserInOrganization.Filter;
using Services.UserInOrganization.Service;
using Services.UserInOrganization.Sort;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.UserInOrganization
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class UserInOrganizationController : BaseClientZoneController
    {
        private readonly IUserInOrganizationService _userInOrganizationService;

        public UserInOrganizationController(
            ILogger<UserInOrganizationController> logger,
            IUserInOrganizationService organizationSettingService,
            IOrganizationRoleService organizationRoleService,
            ICourseService courseService
        )
            : base(logger, organizationRoleService)
        {
            _userInOrganizationService = organizationSettingService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(UserInOrganizationCreateDto addUserToOrganizationDto)
        {
            try
            {
                await CheckOrganizationPermition(addUserToOrganizationDto.OrganizationId);
                return await SendResponse(await _userInOrganizationService.AddObject(addUserToOrganizationDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserInOrganizationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List(
            [FromQuery] ListDeletedRequestDto list,
            [FromQuery] UserInOrganizationFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] UserInOrganizationSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                await CheckOrganizationPermition(list.ParentId);
                var result = await _userInOrganizationService.GetList(
                        x => x.OrganizationId == list.ParentId,
                        list.IsDeleted,
                        GetClientCulture(),
                        filter,
                        sortColum.ToString(),
                        sortDirection,
                        paging
                    );
                return await SendResponse(
                    result
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserInOrganizationDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail(Guid userId, Guid organizationId)
        {
            try
            {
                await CheckOrganizationPermition(organizationId);
                return await SendResponse(
                    await _userInOrganizationService.GetDetail(x => x.UserId == userId && x.OrganizationId == organizationId, GetClientCulture())
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Update(UserInOrganizationUpdateDto updateUserInOrganizationRoleDto)
        {
            try
            {
                await CheckOrganizationPermition(updateUserInOrganizationRoleDto.OrganizationId);
                return await SendResponse(await _userInOrganizationService.UpdateObject(updateUserInOrganizationRoleDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Delete(Guid userId, Guid organizationId)
        {
            try
            {
                await CheckOrganizationPermition(organizationId);
                return await SendResponse(
                    await _userInOrganizationService.MultipleDelete(
                        x => x.UserId == userId && x.OrganizationId == organizationId && x.SystemIdentificator != OrganizationRole.ORGANIZATION_OWNER,
                        GetLoggedUserId()
                    )
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserOrganizationRoleDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public Task<ActionResult> Check([FromQuery] Guid objectId, [FromQuery] string type)
        {
            try
            {
                if (type == "courseBrowse")
                {
                    return SendResponse(_userInOrganizationService.CanCourseBrowse(objectId, GetLoggedUserId()));
                }
                else if (type == "showStudentTestResult")
                {
                    return SendResponse(_userInOrganizationService.CanShowStudentTestResult(objectId, GetLoggedUserId()));
                }
                return SendResponse(
                    _userInOrganizationService.GetDetail(x => x.UserId == GetLoggedUserId() && x.OrganizationId == objectId, GetClientCulture())
                );
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<OrganizationRoleListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetOrganizationRoles()
        {
            try
            {
                return await SendResponse(await _userInOrganizationService.GetOrganizationRoles());
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
