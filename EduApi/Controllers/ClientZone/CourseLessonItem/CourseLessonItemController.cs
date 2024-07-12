using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Edu.CourseLessonItem;
using Services.CourseLessonItem.Dto;
using Services.CourseLessonItem.Service;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduApi.Controllers.ClientZone.CourseLessonItem
{
    [ApiExplorerSettings(GroupName = "CourseMaterial")]
    public class CourseLessonItemController : BaseClientZoneController
    {
        private readonly ICourseLessonItemService _courseLessonItemService;

        public CourseLessonItemController(
            ILogger<CourseLessonItemController> logger,
            ICourseLessonItemService courseLessonItemSerice,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _courseLessonItemService = courseLessonItemSerice;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Create(CourseLessonItemCreateDto courseLessonItemCreateDto)
        {
            try
            {
                CheckOrganizationPermition(_courseLessonItemService.GetOrganizationIdByObjectId(courseLessonItemCreateDto.CourseLessonId));
                return SendResponse(_courseLessonItemService.AddObject(courseLessonItemCreateDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseLessonItemListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto request)
        {
            CheckOrganizationPermition(_courseLessonItemService.GetOrganizationIdByObjectId(request.ParentId));
            return SendResponse(_courseLessonItemService.GetList(x => x.CourseLessonId == request.ParentId, request.IsDeleted, GetClientCulture()));
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseLessonItemDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            CheckOrganizationPermition(_courseLessonItemService.GetOrganizationIdByObjectId(request.Id));
            return SendResponse(_courseLessonItemService.GetDetail(request.Id, GetClientCulture()));
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Update(CourseLessonItemUpdateDto updateCourseLessonItemDto)
        {
            try
            {
                CheckOrganizationPermition(_courseLessonItemService.GetOrganizationIdByObjectId(updateCourseLessonItemDto.Id));
                return SendResponse(_courseLessonItemService.UpdateObject(updateCourseLessonItemDto, GetLoggedUserId(), GetClientCulture()));
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
                CheckOrganizationPermition(_courseLessonItemService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseLessonItemService.DeleteObject(request.Id, GetLoggedUserId()));
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
                CheckOrganizationPermition(_courseLessonItemService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseLessonItemService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult FileUpload([FromQuery] DetailRequestDto request, IFormFile file)
        {
            try
            {
                CheckOrganizationPermition(_courseLessonItemService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(
                    _courseLessonItemService.FileUpload(
                        request.Id,
                        GetClientCulture(),
                        GetLoggedUserId(),
                        new List<IFormFile>() { file },
                        new CourseLessonItemFileRepositoryDbo() { CourseLessonItemId = request.Id, }
                    )
                );
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
        public ActionResult FileDelete([FromQuery] DeleteDto request)
        {
            try
            {
                CheckOrganizationPermition(_courseLessonItemService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseLessonItemService.FileDelete(request.Id, GetLoggedUserId()));
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
        public ActionResult UpdatePositionCourseLessonItem(CourseLessonItemUpdatePositionDto updatePositionCourseLessonItemDto)
        {
            try
            {
                CheckOrganizationPermition(
                    _courseLessonItemService.GetOrganizationIdByObjectId(Guid.Parse(updatePositionCourseLessonItemDto.Ids.First()))
                );
                return SendResponse(_courseLessonItemService.UpdatePositionCourseLessonItem(updatePositionCourseLessonItemDto, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
