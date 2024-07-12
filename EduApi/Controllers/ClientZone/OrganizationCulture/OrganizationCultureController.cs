using System;
using System.Web.Helpers;
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
        public ActionResult Create(OrganizationCultureCreateDto addCourseDto)
        {
            try
            {
                CheckOrganizationPermition(addCourseDto.OrganizationId);
                return SendResponse(_organizationCultureService.AddObject(addCourseDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrganizationCultureListDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List(
            [FromQuery] ListDeletedRequestDto listRequest,
            [FromQuery] OrganizationCultureFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] OrganizationCultureSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                CheckOrganizationPermition(listRequest.ParentId);
                return SendResponse(
                    _organizationCultureService.GetList(
                        x => x.OrganizationId == listRequest.ParentId,
                        listRequest.IsDeleted,
                        GetClientCulture(),
                        filter,
                        sortColum.ToString(),
                        sortDirection,
                        paging
                    )
                );
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Update(OrganizationCultureUpdateDto update)
        {
            try
            {
                update.OrganizationId = _organizationCultureService.GetOrganizationIdByObjectId(update.Id);
                CheckOrganizationPermition(update.OrganizationId);
                return SendResponse(_organizationCultureService.UpdateObject(update, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Delete([FromQuery] DeleteDto request)
        {
            try
            {
                CheckOrganizationPermition(_organizationCultureService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_organizationCultureService.DeleteObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Restore([FromQuery] RestoreDto request)
        {
            try
            {
                CheckOrganizationPermition(_organizationCultureService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_organizationCultureService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
