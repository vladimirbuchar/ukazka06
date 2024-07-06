using Core.Base.Dto;
using Core.DataTypes;
using EduServices.ClassRoom.Dto;
using EduServices.ClassRoom.Service;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.ClassRoom
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class ClassRoomController : BaseClientZoneController
    {
        private readonly IClassRoomService _classRoomService;

        public ClassRoomController(
            ILogger<ClassRoomController> logger,
            IClassRoomService classRoomService,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _classRoomService = classRoomService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        [ProducesResponseType(typeof(void), 404)]
        public ActionResult Create(ClassRoomCreateDto addClassRoomDto)
        {
            try
            {
                CheckOrganizationPermition(_classRoomService.GetOrganizationIdByObjectId(addClassRoomDto.BranchId));
                return SendResponse(_classRoomService.AddObject(addClassRoomDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClassRoomListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                CheckOrganizationPermition(_classRoomService.GetOrganizationIdByObjectId(request.ParentId));
                return SendResponse(_classRoomService.GetList(x => x.BranchId == request.ParentId, request.IsDeleted, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ClassRoomDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckOrganizationPermition(_classRoomService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_classRoomService.GetDetail(request.Id, GetClientCulture()));
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
        public ActionResult Update(ClassRoomUpdateDto updateClassRoomDto)
        {
            try
            {
                CheckOrganizationPermition(_classRoomService.GetOrganizationIdByObjectId(updateClassRoomDto.Id));
                return SendResponse(_classRoomService.UpdateObject(updateClassRoomDto, GetLoggedUserId(), GetClientCulture()));
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
                CheckOrganizationPermition(_classRoomService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_classRoomService.DeleteObject(request.Id, GetLoggedUserId()));

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
                CheckOrganizationPermition(_classRoomService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_classRoomService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClassRoomListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllClassRoomInOrganization([FromQuery] ListRequestDto list)
        {
            try
            {
                CheckOrganizationPermition(list.ParentId);
                return SendResponse(_classRoomService.GetList(
                    x => x.Branch.OrganizationId == list.ParentId, false
                    , GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ClassRoomTimeTableDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetClassRoomTimeTable([FromQuery] ListRequestDto requestDto)
        {
            try
            {
                CheckOrganizationPermition(_classRoomService.GetOrganizationIdByObjectId(requestDto.ParentId));
                return SendResponse(_classRoomService.GetClassRoomTimeTable(requestDto.ParentId, _classRoomService.GetOrganizationIdByObjectId(requestDto.ParentId), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
