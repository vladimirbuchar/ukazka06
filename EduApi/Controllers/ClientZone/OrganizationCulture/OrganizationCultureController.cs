using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationCulture.Dto;
using Services.OrganizationCulture.Filter;
using Services.OrganizationCulture.Service;
using Services.OrganizationCulture.Sort;
using Services.OrganizationRole.Service;
using System;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.OrganizationCulture
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class OrganizationCultureController : BaseClientZoneController
    {
        private readonly IOrganizationCultureService _organizationCultureService;

        public OrganizationCultureController(
            ILogger<OrganizationCultureController> logger,
            IOrganizationCultureService organizationCultureService,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _organizationCultureService = organizationCultureService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(OrganizationCultureCreateDto addCourseDto)
        {
            try
            {
                await CheckOrganizationPermition(addCourseDto.OrganizationId);
                return await SendResponse(await _organizationCultureService.AddObject(addCourseDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrganizationCultureListDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List(
            [FromQuery] ListDeletedRequestDto listRequest,
            [FromQuery] OrganizationCultureFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] OrganizationCultureSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                await CheckOrganizationPermition(listRequest.ParentId);
                var result = await _organizationCultureService.GetList(
                        x => x.OrganizationId == listRequest.ParentId,
                        listRequest.IsDeleted,
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

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Update(OrganizationCultureUpdateDto update)
        {
            try
            {
                update.OrganizationId = await _organizationCultureService.GetOrganizationIdByObjectId(update.Id);
                await CheckOrganizationPermition(update.OrganizationId);
                return await SendResponse(await _organizationCultureService.UpdateObject(update, GetLoggedUserId(), GetClientCulture()));
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
        public async Task<ActionResult> Delete([FromQuery] DeleteDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _organizationCultureService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _organizationCultureService.DeleteObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Restore([FromQuery] RestoreDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _organizationCultureService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _organizationCultureService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
