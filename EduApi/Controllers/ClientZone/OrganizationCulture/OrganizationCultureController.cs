using System;
using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationCulture.Dto;
using Services.OrganizationCulture.Service;
using Services.OrganizationRole.Service;

namespace EduApi.Controllers.ClientZone.OrganizationCulture
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class OrganizationCultureController : BaseClientZoneController
    {
        private readonly IOrganizationCultureService _organizationSettingService;

        public OrganizationCultureController(ILogger<OrganizationCultureController> logger, IOrganizationCultureService organizationSettingService, IOrganizationRoleService organizationRoleService)
            : base(logger, organizationRoleService)
        {
            _organizationSettingService = organizationSettingService;
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
                return SendResponse(_organizationSettingService.AddObject(addCourseDto, GetLoggedUserId(), GetClientCulture()));
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
        public ActionResult List([FromQuery] ListDeletedRequestDto listRequest)
        {
            try
            {
                CheckOrganizationPermition(listRequest.ParentId);
                return SendResponse(_organizationSettingService.GetList(x => x.OrganizationId == listRequest.ParentId, listRequest.IsDeleted));
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
                update.OrganizationId = _organizationSettingService.GetOrganizationIdByObjectId(update.Id);
                CheckOrganizationPermition(update.OrganizationId);
                return SendResponse(_organizationSettingService.UpdateObject(update, GetLoggedUserId(), GetClientCulture()));
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
                CheckOrganizationPermition(_organizationSettingService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_organizationSettingService.DeleteObject(request.Id, GetLoggedUserId()));
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
                CheckOrganizationPermition(_organizationSettingService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_organizationSettingService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
