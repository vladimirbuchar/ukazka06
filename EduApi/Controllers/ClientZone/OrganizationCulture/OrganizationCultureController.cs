using Core.Base.Dto;
using Core.DataTypes;
using EduServices.OrganizationCulture.Dto;
using EduServices.OrganizationCulture.Service;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EduApi.Controllers.ClientZone.OrganizationCulture
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class OrganizationCultureController : BaseClientZoneController
    {
        private readonly IOrganizationCultureService _organizationSettingService;

        public OrganizationCultureController(
            ILogger<OrganizationCultureController> logger,
            IOrganizationCultureService organizationSettingService,
            IOrganizationRoleService organizationRoleService
        )
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
                CheckPermition(addCourseDto.OrganizationId);
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
                CheckPermition(listRequest.ParentId);
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
                CheckPermition(GetOrganizationByOrganizationCulture(update.Id));
                _organizationSettingService.UpdateObject(update, GetLoggedUserId(), GetClientCulture());
                return SendResponse();
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
                CheckPermition(GetOrganizationByOrganizationCulture(request.Id));
                _organizationSettingService.DeleteObject(request.Id, GetLoggedUserId());
                return SendResponse();
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
                CheckPermition(GetOrganizationByOrganizationCulture(request.Id));
                _organizationSettingService.RestoreObject(request.Id, GetLoggedUserId());
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
